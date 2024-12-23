﻿using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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

                hospPatient1.Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
                hospPatient1.PatientName = reader["PatientName"] != DBNull.Value ? reader["PatientName"].ToString() : string.Empty;
                hospPatient1.AdmissionDate = reader["AdmissionDate"] != DBNull.Value ? reader["AdmissionDate"].ToString() : string.Empty;
                hospPatient1.DischargeDate = reader["DischargeDate"] != DBNull.Value ? reader["DischargeDate"].ToString() : string.Empty;
                hospPatient1.PatientType = reader["PatientType"] != DBNull.Value ? reader["PatientType"].ToString() : string.Empty;
                hospPatient1.TreatmentDuration = reader["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(reader["TreatmentDuration"]) : 0;
                hospPatient1.Date = reader["Date"] != DBNull.Value ? reader["Date"].ToString() : string.Empty;
                hospPatient1.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty;
                hospPatient1.Problem = reader["Problem"] != DBNull.Value ? reader["Problem"].ToString() : string.Empty;
                hospPatient1.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty;
                hospPatient1.Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty;
                hospPatient1.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty;
                hospPatient1.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : string.Empty;

                hospPatients.Add(hospPatient1);

            }
            reader.Close();
            con.Close();
            return hospPatients;

        }


        public HospPatient OPID (int Id)
        {
            HospPatient hospPatient = null;
            con.Open();
            cmd = new SqlCommand("Select * from Bookapp where Id=" + Id + "", con);
            reader= cmd.ExecuteReader();

            if (reader.Read())
            {
                hospPatient = new HospPatient
                {
                    Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                    PatientName = reader["PatientName"] != DBNull.Value ? reader["PatientName"].ToString() : string.Empty,
                    AdmissionDate = reader["AdmissionDate"] != DBNull.Value ? reader["AdmissionDate"].ToString() : string.Empty,
                    DischargeDate = reader["DischargeDate"] != DBNull.Value ? reader["DischargeDate"].ToString() : string.Empty,
                    PatientType = reader["PatientType"] != DBNull.Value ? reader["PatientType"].ToString() : string.Empty,
                    TreatmentDuration = reader["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(reader["TreatmentDuration"]) : 0,
                    Date = reader["Date"] != DBNull.Value ? reader["Date"].ToString() : string.Empty,
                    Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty,
                    Problem = reader["Problem"] != DBNull.Value ? reader["Problem"].ToString() : string.Empty,
                    Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty,
                    Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty,
                    Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty,
                    PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : string.Empty


                };
            
            }

            reader.Close();
            con.Close ();
            return hospPatient;

        }


        public List<HospPatient> GetHospPatients()
        {
            List<HospPatient> hospPatients = new List<HospPatient>();
            HospPatient hospPatient1 = null;
            con.Open();
            cmd = new SqlCommand("select * from Bookapp ", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                hospPatient1 = new HospPatient();

                hospPatient1.Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0;
                hospPatient1.PatientName = reader["PatientName"] != DBNull.Value ? reader["PatientName"].ToString() : string.Empty;
                hospPatient1.AdmissionDate = reader["AdmissionDate"] != DBNull.Value ? reader["AdmissionDate"].ToString() : string.Empty;
                hospPatient1.DischargeDate = reader["DischargeDate"] != DBNull.Value ? reader["DischargeDate"].ToString() : string.Empty;
                hospPatient1.PatientType = reader["PatientType"] != DBNull.Value ? reader["PatientType"].ToString() : string.Empty;
                hospPatient1.TreatmentDuration = reader["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(reader["TreatmentDuration"]) : 0;
                hospPatient1.Date = reader["Date"] != DBNull.Value ? reader["Date"].ToString() : string.Empty;
                hospPatient1.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty;
                hospPatient1.Problem = reader["Problem"] != DBNull.Value ? reader["Problem"].ToString() : string.Empty;
                hospPatient1.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty;
                hospPatient1.Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty;
                hospPatient1.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty;
                hospPatient1.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : string.Empty;

                hospPatients.Add(hospPatient1);

            }
            reader.Close();
            con.Close();
            return hospPatients;


        }

        //Add
        public List<HospPatient> AddPatients(HospPatient hosp)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from bookapp where Id='" + hosp.Id + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["Id"]);
            }

            reader.Close();
            con.Close();



            con.Open();


            if (ids == 0)
            {
                cmd = new SqlCommand("insert into bookapp(Id,PatientName,AdmissionDate,DischargeDate,PatientType,TreatmentDuration,Date,Status,Problem,Description,Gender,Address,PhoneNumber) values(" + hosp.Id + ",'" + hosp.PatientName + "','" + hosp.AdmissionDate + "','" + hosp.DischargeDate + "','" + hosp.PatientType + "','" + hosp.TreatmentDuration + "','" + hosp.Date + "','" + hosp.Status + "','" + hosp.Problem + "','" + hosp.Description + "','" + hosp.Gender + "','" + hosp.Address + "','" + hosp.PhoneNumber + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update bookapp set PatientName='" + hosp.PatientName + "',AdmissionDate='" + hosp.AdmissionDate + "',DischargeDate='" + hosp.DischargeDate + "',PatientType='" + hosp.PatientType + "',TreatmentDuration='" + hosp.TreatmentDuration + "',Date='" + hosp.Date + "',Status='" + hosp.Status + "',Problem='" + hosp.Problem + "',Description='" + hosp.Description + "',Gender='" + hosp.Gender + "',Address='" + hosp.Address + "',PhoneNumber='" + hosp.PhoneNumber + "' where Id=" + hosp.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<HospPatient> list = new List<HospPatient>();
            list = GetHospPatients();
            return list;
        }




        //Edit
        public HospPatient PatientEdit(int Id)
        {
            HospPatient hosp = new HospPatient();


            SqlCommand cmd = new SqlCommand("Select * from bookapp where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    hosp.Id = Convert.ToInt32(reader["Id"]);
                    hosp.PatientName = reader["PatientName"] != DBNull.Value ? reader["PatientName"].ToString() : string.Empty;
                    hosp.AdmissionDate = reader["AdmissionDate"] != DBNull.Value ? reader["AdmissionDate"].ToString() : string.Empty;
                    hosp.DischargeDate = reader["DischargeDate"] != DBNull.Value ? reader["DischargeDate"].ToString() : string.Empty;
                    hosp.PatientType = reader["PatientType"] != DBNull.Value ? reader["PatientType"].ToString() : string.Empty;
                    hosp.TreatmentDuration = reader["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(reader["TreatmentDuration"]) : 0;  // Default to 0 if null
                    hosp.Date = reader["Date"] != DBNull.Value ? reader["Date"].ToString() : string.Empty;
                    hosp.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty;
                    hosp.Problem= reader["Problem"] != DBNull.Value ? reader["Problem"].ToString() : string.Empty;
                    hosp.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty;
                    hosp.Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty;
                    hosp.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty;
                    hosp.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : string.Empty;



                }
                reader.Close();
                con.Close();

            }
            return hosp;
        }


        //Id increment

        public int CommonId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM bookapp", con);
            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }


      

    }
}