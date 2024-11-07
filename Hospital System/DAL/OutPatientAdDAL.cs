using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Hospital_System.Models;
using System.Data;

namespace Hospital_System.DAL
{
    public class OutPatientAdDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public OutPatientAdDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        public List<MInPatient> OutPatientList()
        {
            List<MInPatient> mInPatients = new List<MInPatient>();

            {

                con.Open();
                cmd = new SqlCommand("select * from bookapp", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    mInPatients.Add(
                        new MInPatient
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            PatientName = row["PatientName"].ToString(),
                            Problem = row["Problem"].ToString(),
                            Description = row["Description"].ToString(),
                            Gender = row["Gender"].ToString(),
                            Address = row["Address"].ToString(),
                            //PatientType = row["PatientType"].ToString(),
                            PhoneNumber = row["PhoneNumber"].ToString(),
                            

                        });

                return mInPatients;
            }
        }

        //Add outpatient details

        public List<MInPatient> AddOutPatient(MInPatient mInPatient)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from bookapp where Id='" + mInPatient.Id + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["PatientId"]);
            }

            reader.Close();
            con.Close();



            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into bookapp(Id,PatientName,Problem,Description,Gender,Address,PhoneNumber) values(" + mInPatient.Id + ",'" + mInPatient.PatientName + "','" + mInPatient.Problem + "','" + mInPatient.Description + "','" + mInPatient.Gender + "','" + mInPatient.Address + "','" + mInPatient.PhoneNumber + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update bookapp set PatientName='" + mInPatient.PatientName + "',Problem='" + mInPatient.Problem + "',Description='" + mInPatient.Description + "',Gender='" + mInPatient.Gender + "',Address='" + mInPatient.Address + "',PhoneNumber='" + mInPatient.PhoneNumber + "' where Id=" + mInPatient.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MInPatient> mInPatients = new List<MInPatient>();
            mInPatients = OutPatientList();
            return mInPatients;
        }

        //outpatient Edit

        public MInPatient OutPatientEdit(int Id)
        {
            MInPatient mInPatient = new MInPatient();


            SqlCommand cmd = new SqlCommand("Select * from bookapp where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    mInPatient.Id = Convert.ToInt32(reader["Id"]);
                    mInPatient.PatientName = reader["PatientName"].ToString();
                    mInPatient.Problem = reader["Problem"].ToString();
                    mInPatient.Description = reader["Description"].ToString();
                    mInPatient.Gender = reader["Gender"].ToString();
                    //mInPatient.PatientType = reader["PatientType"].ToString();
                    mInPatient.Address = reader["Address"].ToString();
                    mInPatient.PhoneNumber = reader["PhoneNumber"].ToString();
                    

                }
                reader.Close();
                con.Close();

            }
            return mInPatient;
        }

        //outpatient delete

        public List<MInPatient> OutPatientDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from bookapp where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<MInPatient> mInPatients = new List<MInPatient>();

            con.Open();
            cmd = new SqlCommand("select * from bookapp", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MInPatient mInPatient = new MInPatient();

                mInPatient.Id = Convert.ToInt32(reader["Id"]);
                mInPatient.PatientName = reader["PatientName"].ToString();
                mInPatient.Problem = reader["Problem"].ToString();
                mInPatient.Description = reader["Description"].ToString();
                mInPatient.Gender = reader["Gender"].ToString();
                //mInPatient.PatientType = reader["PatientType"].ToString();
                mInPatient.Address = reader["Address"].ToString();
                mInPatient.PhoneNumber = reader["PhoneNumber"].ToString();
               

                mInPatients.Add(mInPatient);

            }

            reader.Close();
            con.Close();
            return mInPatients;
        }


        //outPatient Auto Increment Id
        public int OutpatientId()
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