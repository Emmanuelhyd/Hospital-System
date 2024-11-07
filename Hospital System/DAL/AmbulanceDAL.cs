using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class AmbulanceDAL
    {

        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public AmbulanceDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public List<AmbulanceDetails> GetAmbulanceDetails()
        {
            List<AmbulanceDetails>ambulanceDetails = new List<AmbulanceDetails>();

            con.Open();
            cmd= new SqlCommand("select * from Amb",con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AmbulanceDetails ambulanceDetails1 = new AmbulanceDetails();

                ambulanceDetails1.Id = Convert.ToInt32(reader["Id"]);
                ambulanceDetails1.Name = reader.GetString(reader.GetOrdinal("Name"));
                ambulanceDetails1.AmbulanceId = Convert.ToInt32(reader["AmbulanceId"]);
                ambulanceDetails1.AmbulanceStatus = reader.GetString(reader.GetOrdinal("AmbulanceStatus"));
                ambulanceDetails1.DriverName = reader.GetString(reader.GetOrdinal("DriverName"));
                ambulanceDetails1.DriverId = reader.GetString(reader.GetOrdinal("DriverId"));

                ambulanceDetails.Add(ambulanceDetails1);
            }

            reader.Close();
            con.Close();
            return ambulanceDetails;
        }
    }
}