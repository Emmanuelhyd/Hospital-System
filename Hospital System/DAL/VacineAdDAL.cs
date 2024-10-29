using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;

namespace Hospital_System.DAL
{
    public class VacineDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public VacineDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //List

        public List<VaccineDo> VaccineListAdmin()
        {
            List<VaccineDo> vaccineDos = new List<VaccineDo>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Vaccine", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    vaccineDos.Add(
                        new VaccineDo
                        {
                            PatientId = Convert.ToInt32(row["PatientId"]),
                            PatientName = row["PatientName"].ToString(),
                            DoctorName = row["DoctorName"].ToString(),
                            Age = row["Age"].ToString(),
                            VaccineId = row["VaccineId"].ToString(),
                            VaccineType = row["VaccineType"].ToString(),
                            Dosage = row["Dosage"].ToString(),
                            DateOfVaccination = row["DateOfVaccination"].ToString(),
                            FollowupDate = row["FollowupDate"].ToString(),
                            NextDueDate = row["NextDueDate"].ToString(),
                            ReactionType = row["ReactionType"].ToString(),
                            Status = row["Status"].ToString(),


                        });

                return vaccineDos;
            }
        }


        //Add Vaccine

        public List<VaccineDo> AddVaccine(VaccineDo vaccineDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Vaccine where PatientId='" + vaccineDo.PatientId + "'", con);
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
                cmd = new SqlCommand("insert into Vaccine(PatientId,PatientName,DoctorName,Age,VaccineId,VaccineType,Dosage,DateOfVaccination,FollowupDate,NextDueDate,ReactionType,Status) values(" + vaccineDo.PatientId + ",'" + vaccineDo.PatientName + "','" + vaccineDo.DoctorName + "','" + vaccineDo.Age + "','" + vaccineDo.VaccineId + "','" + vaccineDo.VaccineType + "','" + vaccineDo.Dosage + "','" + vaccineDo.DateOfVaccination + "','" + vaccineDo.FollowupDate + "','" + vaccineDo.NextDueDate + "','" + vaccineDo.ReactionType + "','" + vaccineDo.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Vaccine set PatientName='" + vaccineDo.PatientName + "',DoctorName='" + vaccineDo.DoctorName + "',Age='" + vaccineDo.Age + "',VaccineId='" + vaccineDo.VaccineId + "',VaccineType='" + vaccineDo.VaccineType + "',Dosage='" + vaccineDo.Dosage + "',DateOfVaccination='" + vaccineDo.DateOfVaccination + "',FollowupDate='" + vaccineDo.FollowupDate + "',NextDueDate='" + vaccineDo.NextDueDate + "',ReactionType='" + vaccineDo.ReactionType + "',Status='" + vaccineDo.Status + "' where PatientId=" + vaccineDo.PatientId + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<VaccineDo> vaccineDos = new List<VaccineDo>();
            vaccineDos = VaccineListAdmin();
            return vaccineDos;
        }

        //Vaccine Id Increment

        public int VaccineId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(PatientId) FROM Vaccine", con);
            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }



        //vaccine edit

        public VaccineDo VaccineEdit(int PatientId)
        {
            VaccineDo vaccineDo = new VaccineDo();


            SqlCommand cmd = new SqlCommand("Select * from Vaccine where PatientId='" + PatientId + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    vaccineDo.PatientId = Convert.ToInt32(reader["PatientId"]);
                    vaccineDo.PatientName = reader["PatientName"].ToString();
                    vaccineDo.DoctorName = reader["DoctorName"].ToString();
                    vaccineDo.Age = reader["Age"].ToString();
                    vaccineDo.VaccineId = reader["VaccineId"].ToString();
                    vaccineDo.VaccineType = reader["VaccineType"].ToString();
                    vaccineDo.Dosage = reader["Dosage"].ToString();
                    vaccineDo.DateOfVaccination = reader["DateOfVaccination"].ToString();
                    vaccineDo.FollowupDate = reader["FollowupDate"].ToString();
                    vaccineDo.NextDueDate = reader["NextDueDate"].ToString();
                    vaccineDo.ReactionType = reader["ReactionType"].ToString();
                    vaccineDo.Status = reader["Status"].ToString();


                }
                reader.Close();
                con.Close();

            }
            return vaccineDo;
        }
        // delete vaccine

        public List<VaccineDo> VaccineDelete(int PatientId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Vaccine where PatientId='" + PatientId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<VaccineDo> vaccineDos = new List<VaccineDo>();

            con.Open();
            cmd = new SqlCommand("select * from Vaccine", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VaccineDo vaccineDo = new VaccineDo();

                vaccineDo.PatientId = Convert.ToInt32(reader["PatientId"]);
                vaccineDo.PatientName = reader["PatientName"].ToString();
                vaccineDo.DoctorName = reader["DoctorName"].ToString();
                vaccineDo.Age = reader["Age"].ToString();
                vaccineDo.VaccineId = reader["VaccineId"].ToString();
                vaccineDo.VaccineType = reader["VaccineType"].ToString();
                vaccineDo.Dosage = reader["Dosage"].ToString();
                vaccineDo.DateOfVaccination = reader["DateOfVaccination"].ToString();
                vaccineDo.FollowupDate = reader["FollowupDate"].ToString();
                vaccineDo.NextDueDate = reader["NextDueDate"].ToString();
                vaccineDo.ReactionType = reader["ReactionType"].ToString();
                vaccineDo.Status = reader["Status"].ToString();


                vaccineDos.Add(vaccineDo);

            }

            reader.Close();
            con.Close();
            return vaccineDos;
        }

    }
}