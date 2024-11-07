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
                            PatientName = row["PatientName"] == DBNull.Value ? string.Empty : row["PatientName"].ToString(),

                            AdmissionDate = row["AdmissionDate"] != DBNull.Value ? row["AdmissionDate"].ToString() : string.Empty,
                            DischargeDate = row["DischargeDate"] != DBNull.Value ? row["DischargeDate"].ToString() : string.Empty,
                            PatientType = row["PatientType"] != DBNull.Value ? row["PatientType"].ToString() : string.Empty,
                            TreatmentDuration = row["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(row["TreatmentDuration"]) : 0,
                            Date = row["Date"] != DBNull.Value ? row["Date"].ToString() : string.Empty,
                            Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : string.Empty,
                            Problem = row["Problem"] != DBNull.Value ? row["Problem"].ToString() : string.Empty,
                            Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : string.Empty,
                            Gender = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : string.Empty,
                            Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : string.Empty,
                            PhoneNumber = row["PhoneNumber"] != DBNull.Value ? row["PhoneNumber"].ToString() : string.Empty



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
                    mInPatient.PatientName = reader["PatientName"] != DBNull.Value ? reader["PatientName"].ToString() : string.Empty;
                    mInPatient.AdmissionDate = reader["AdmissionDate"] != DBNull.Value ? reader["AdmissionDate"].ToString() : string.Empty;
                    mInPatient.DischargeDate = reader["DischargeDate"] != DBNull.Value ? reader["DischargeDate"].ToString() : string.Empty;
                    mInPatient.PatientType = reader["PatientType"] != DBNull.Value ? reader["PatientType"].ToString() : string.Empty;
                    mInPatient.TreatmentDuration = reader["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(reader["TreatmentDuration"]) : 0;  // Default to 0 if null
                    mInPatient.Date = reader["Date"] != DBNull.Value ? reader["Date"].ToString() : string.Empty;
                    mInPatient.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty;
                    mInPatient.Problem = reader["Problem"] != DBNull.Value ? reader["Problem"].ToString() : string.Empty;
                    mInPatient.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty;
                    mInPatient.Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty;
                    mInPatient.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty;
                    mInPatient.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : string.Empty;



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
                mInPatient.PatientName = reader["PatientName"] != DBNull.Value ? reader["PatientName"].ToString() : string.Empty;
                mInPatient.AdmissionDate = reader["AdmissionDate"] != DBNull.Value ? reader["AdmissionDate"].ToString() : string.Empty;
                mInPatient.DischargeDate = reader["DischargeDate"] != DBNull.Value ? reader["DischargeDate"].ToString() : string.Empty;
                mInPatient.PatientType = reader["PatientType"] != DBNull.Value ? reader["PatientType"].ToString() : string.Empty;
                mInPatient.TreatmentDuration = reader["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(reader["TreatmentDuration"]) : 0;  // Default to 0 if null
                mInPatient.Date = reader["Date"] != DBNull.Value ? reader["Date"].ToString() : string.Empty;
                mInPatient.Status = reader["Status"] != DBNull.Value ? reader["Status"].ToString() : string.Empty;
                mInPatient.Problem = reader["Problem"] != DBNull.Value ? reader["Problem"].ToString() : string.Empty;
                mInPatient.Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : string.Empty;
                mInPatient.Gender = reader["Gender"] != DBNull.Value ? reader["Gender"].ToString() : string.Empty;
                mInPatient.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : string.Empty;
                mInPatient.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : string.Empty;


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