using Microsoft.Win32.SafeHandles;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class ConsultDAL
    {
        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public ConsultDAL()
         {  
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);

         }


        public List<HospPatient>CHospPatient()
        {
            List<HospPatient> hospPatients = new List<HospPatient>();
            con.Open();
            cmd = new SqlCommand("select * from Bookapp ", con);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                HospPatient hospPatient = new HospPatient();

                int ordinalId = reader.GetOrdinal("Id");
                hospPatient.Id = reader.IsDBNull(ordinalId) ? 0 : Convert.ToInt32(reader.GetValue(ordinalId));

                hospPatient.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                hospPatient.DoctorName = reader.IsDBNull(reader.GetOrdinal("DoctorName")) ? null : reader.GetString(reader.GetOrdinal("DoctorName"));
                hospPatient.Date = reader.GetString(reader.GetOrdinal("Date"));
                hospPatient.Problem= reader.GetString(reader.GetOrdinal("Problem"));
                hospPatient.Description = reader.GetString(reader.GetOrdinal("Description"));
                hospPatient.Address = reader.GetString(reader.GetOrdinal("Address"));
                //hospPatient.TypeName = reader.GetString(reader.GetOrdinal("TypeName"));
                hospPatient.Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status"));

                hospPatients.Add(hospPatient);

            }

            reader.Close();
            con.Close();
            return hospPatients;
        }

        public List<HospPatient>ConsultDoc(string DoctorName)
        {
            List<HospPatient> hospPatients = new List<HospPatient>();

            con.Open();
            cmd = new SqlCommand("select * from Bookapp where DoctorName ='" + DoctorName + "'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HospPatient hospPatient = new HospPatient();

                hospPatient.PatientName = reader.GetString(reader.GetOrdinal("PatientName"));
                hospPatient.DoctorName = reader.GetString(reader.GetOrdinal("DoctorName"));
                hospPatient.Problem = reader.GetString(reader.GetOrdinal("Problem"));
                hospPatient.Description = reader.GetString(reader.GetOrdinal("Description"));
                hospPatient.Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status"));

                hospPatients.Add(hospPatient);
            }
            reader.Close();
            con.Close();
            return hospPatients;
        }



    }
}