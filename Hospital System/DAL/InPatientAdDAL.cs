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
    public class InPatientAdDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public InPatientAdDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //inPatientList

        public List<MInPatient> InPatientListAd()
        {
            List<MInPatient> mInPatients = new List<MInPatient>();

            {

                con.Open();
                cmd = new SqlCommand("select * from bookapp Where PatientType like '%In Patient%' ", con);
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

                            TreatmentDuration = row["TreatmentDuration"] != DBNull.Value ? Convert.ToInt32(row["TreatmentDuration"]) : 0, // or a specific default value

                            Date = row["Date"].ToString(),

                            Status = row["Status"].ToString()


                        });

                return mInPatients;
            }
        }

        //Add Inpatient details

        public List<MInPatient> AddInpatient(MInPatient mInPatient)
        {

            if (mInPatient.PatientType != "In Patient")
            {
                // Return an empty list if the PatientType is not "In Patient"
                return new List<MInPatient>();
            }


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
                cmd = new SqlCommand("insert into bookapp(Id,PatientName,AdmissionDate,DischargeDate,PatientType,TreatmentDuration,Date,Status) values(" + mInPatient.Id + ",'" + mInPatient.PatientName + "','" + mInPatient.AdmissionDate + "','" + mInPatient.DischargeDate + "','" + mInPatient.PatientType + "','" + mInPatient.TreatmentDuration + "','" + mInPatient.Date + "','" + mInPatient.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update bookapp set PatientName='" + mInPatient.PatientName + "',AdmissionDate='" + mInPatient.AdmissionDate + "',DischargeDate='" + mInPatient.DischargeDate + "',PatientType='" + mInPatient.PatientType + "',TreatmentDuration='" + mInPatient.TreatmentDuration + "',Date='" + mInPatient.Date + "',Status='" + mInPatient.Status + "' where Id=" + mInPatient.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<MInPatient> mInPatients = new List<MInPatient>();
            mInPatients = InPatientListAd();
            //return mInPatients;

            return mInPatients.Where(m => m.PatientType == "In Patient").ToList();
        }
    

        //Inpatient Edit

        public MInPatient InPatientEdit(int Id)
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

                }
                reader.Close();
                con.Close();

            }
            return mInPatient;
        }

        //Inpatient delete

        public List<MInPatient> InPatientDelete(int Id)
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
                mInPatient.Status = reader["Status"].ToString();

                mInPatients.Add(mInPatient);

            }

            reader.Close();
            con.Close();
            return mInPatients;
        }


        //InPatient Auto Increment Id
        public int InpatientId()
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

        //public MInPatient GetInPatient(int id)

        //{
        //    MInPatient mInPatient = new MInPatient();
        //    con.Open();
        //    cmd = new SqlCommand("select * from   where  ", con);
        //    reader = cmd.ExecuteReader();

        //    if (reader.Read())
        //    {
        //        mInPatient.PatientId = Convert.ToInt32(reader["id"]);

        //    }

        //    reader.Close();
        //    con.Close();
        //    return mInPatient;
        //}
    }
}