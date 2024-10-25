﻿using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Hospital_System.DAL
{
    public class OPDAL
    {
        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;


        public OPDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        public List<HospPatient>GetPatients()
        {
            List<HospPatient> hospPatients = new List<HospPatient>();
            HospPatient hospPatient1 = null;
            con.Open();
            cmd = new SqlCommand("select * from Bookapp ",con);
            reader= cmd.ExecuteReader();
            while(reader.Read())
            {
               hospPatient1 = new HospPatient();
                int ordinalId = reader.GetOrdinal("Id");
                hospPatient1.Id = reader.IsDBNull(ordinalId) ? 0 : Convert.ToInt32(reader.GetValue(ordinalId));

                hospPatient1.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                hospPatient1.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                hospPatient1. Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"));
                hospPatient1.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                hospPatient1.Address = reader.GetString(reader.GetOrdinal("Address"));
                hospPatient1.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));

                hospPatients.Add(hospPatient1);

            }
            reader.Close();
            con.Close();
            return hospPatients;

        }
    }
}