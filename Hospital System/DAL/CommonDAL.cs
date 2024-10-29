using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Hospital_System.Models;
using System.Data;
using Hospital_System.BAL;

namespace Hospital_System.DAL
{
    public class CommonDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public CommonDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        //CommonList

        public List<MInPatient> CommonList()
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
                            AdmissionDate = row["AdmissionDate"].ToString(),
                            DischargeDate = row["DischargeDate"].ToString(),
                            PatientType = row["PatientType"].ToString(),
                            TreatmentDuration = Convert.ToInt32(row["TreatmentDuration"]),
                            Date = row["Date"].ToString(),
                            Status = row["Status"].ToString(),
                            Problem = row["Problem"].ToString(),
                            Description = row["Description"].ToString(),
                            Gender = row["Gender"].ToString(),
                            Address = row["Address"].ToString(),
                            PhoneNumber = row["PhoneNumber"].ToString(),


                        });


                return mInPatients;
            }
        }


        //logic

        public void OutPatientList(MInPatient mInPatient)
        {
            // Logic to save mInPatient as outpatient in the database
        }

        public void InPatientListAd(MInPatient mInPatient)
        {
            // Logic to save mInPatient as inpatient in the database
        }

        //Add CommonOP

        public List<MInPatient> AddCommonOP(MInPatient mInPatient)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from bookapp where Id='" + mInPatient.Id + "'", con);
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
                cmd = new SqlCommand("insert into bookapp(Id,PatientName,AdmissionDate,DischargeDate,PatientType,TreatmentDuration,Date,Status,Problem,Description,Gender,Address,PhoneNumber) values(" + mInPatient.Id + ",'" + mInPatient.PatientName + "','" + mInPatient.AdmissionDate + "','" + mInPatient.DischargeDate + "','" + mInPatient.PatientType + "','" + mInPatient.TreatmentDuration + "','" + mInPatient.Date + "','" + mInPatient.Status + "','" + mInPatient.Problem + "','" + mInPatient.Description + "','" + mInPatient.Gender + "','" + mInPatient.Address + "','"+mInPatient.PhoneNumber+"')", con);

            }
            else
            {
                cmd = new SqlCommand("update bookapp set PatientName='" + mInPatient.PatientName + "',AdmissionDate='" + mInPatient.AdmissionDate + "',DischargeDate='" + mInPatient.DischargeDate + "',PatientType='" + mInPatient.PatientType + "',TreatmentDuration='" + mInPatient.TreatmentDuration + "',Date='" + mInPatient.Date + "',Status='" + mInPatient.Status + "',Problem='" + mInPatient.Problem + "',Description='" + mInPatient.Description + "',Gender='" + mInPatient.Gender + "',Address='" + mInPatient.Address + "',PhoneNumber='"+mInPatient.PhoneNumber+ "' where Id=" + mInPatient.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MInPatient> mInPatients = new List<MInPatient>();
            mInPatients = CommonList();
            return mInPatients;
        }


        //OP edit

        public MInPatient CommonEdit(int Id)
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
                    mInPatient.AdmissionDate = reader["AdmissionDate"].ToString();
                    mInPatient.DischargeDate = reader["DischargeDate"].ToString();
                    mInPatient.PatientType = reader["PatientType"].ToString();
                    mInPatient.TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]);
                    mInPatient.Date = reader["Date"].ToString();
                    mInPatient.Status = reader["Status"].ToString();
                    mInPatient.Problem = reader["Problem"].ToString();
                    mInPatient.Description = reader["Description"].ToString();
                    mInPatient.Gender = reader["Gender"].ToString();
                    mInPatient.Address = reader["Address"].ToString();
                    mInPatient.PhoneNumber = reader["PhoneNumber"].ToString();


                }
                reader.Close();
                con.Close();

            }
            return mInPatient;
        }
        // delete OP

        public List<MInPatient> CommonDelete(int Id)
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
                mInPatient.AdmissionDate = reader["AdmissionDate"].ToString();
                mInPatient.DischargeDate = reader["DischargeDate"].ToString();
                mInPatient.PatientType = reader["PatientType"].ToString();
                mInPatient.TreatmentDuration = Convert.ToInt32(reader["TreatmentDuration"]);
                mInPatient.Date = reader["Date"].ToString();
                //mInPatient.AdmissionDate = reader["AdmissionDate"].ToString();
                mInPatient.Status = reader["Status"].ToString();
                mInPatient.Problem = reader["Problem"].ToString();
                mInPatient.Description = reader["Description"].ToString();
                mInPatient.Gender = reader["Gender"].ToString();
                mInPatient.Address = reader["Address"].ToString();
                mInPatient.PhoneNumber = reader["PhoneNumber"].ToString();


                mInPatients.Add(mInPatient);

            }

            reader.Close();
            con.Close();
            return mInPatients;
        }


        //Id Icrement CommonOp

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