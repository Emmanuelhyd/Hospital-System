using AdminPages.Models;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class SessionDAL
    {
        string _connectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public SessionDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public Patients GetPaientDetails(decimal patientId)
        {
            Patients patient = new Patients();

            //List<Patients> patients = new List<Patients>();
            con.Open();
            cmd = new SqlCommand("select *from profiles where PatientId=" + patientId + "", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                patient.PatientId = Convert.ToInt32(reader["PatientId"]);
                patient.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                patient.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                patient.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                patient.Email = reader.GetString(reader.GetOrdinal("Email"));
                patient.BloodGroup = reader.GetString(reader.GetOrdinal("BloodGroup"));
                patient.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                patient.Age = reader.GetString(reader.GetOrdinal("Age"));
                patient.PhoneNo = reader.GetString(reader.GetOrdinal("PhoneNo"));
                patient.Address = reader.GetString(reader.GetOrdinal("Address"));
               

               


            }

            reader.Close();
            con.Close();
            return patient;
        }



       

    }
}