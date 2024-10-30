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
    public class ConsultantDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public ConsultantDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //List
        public List<ConsultantDo> ConsultantList()
        {
            List<ConsultantDo> consultantDos = new List<ConsultantDo>();

            {

                con.Open();
                cmd = new SqlCommand("select * from bookapp", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    consultantDos.Add(
                        new ConsultantDo
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            PatientName = row["PatientName"].ToString(),
                            DoctorName = row["DoctorName"].ToString(),
                            Date = row["Date"].ToString(),
                            Problem = row["Problem"].ToString(),
                            Description = row["Description"].ToString(),
                            Address = row["Address"].ToString(),
                            Status = row["Status"].ToString(),


                        });

                return consultantDos;
            }
        }

        //Add Attendance

        public List<ConsultantDo> AddConsultant(ConsultantDo consultantDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from bookapp where Id='" + consultantDo.Id + "'", con);
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
                cmd = new SqlCommand("insert into bookapp(Id,PatientName,DoctorName,AppointmentDate,Problem,Description,Address,Status) values(" + consultantDo.Id + ",'" + consultantDo.PatientName + "','" + consultantDo.DoctorName + "','" + consultantDo.Date + "','" + consultantDo.Problem + "','" + consultantDo.Description + "','" + consultantDo.Address + "','" + consultantDo.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update bookapp set PatientName='" + consultantDo.PatientName + "',DoctorName='" + consultantDo.DoctorName + "',Date='" + consultantDo.Date + "',Problem='" + consultantDo.Problem + "',Description='" + consultantDo.Description + "',Address='" + consultantDo.Address + "',Status='" + consultantDo.Status + "' where Id=" + consultantDo.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<ConsultantDo> consultantDos = new List<ConsultantDo>();
            consultantDos = ConsultantList();
            return consultantDos;
        }

        //Auto increment Id
        public int ConsultantId()
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


        //Attendance Edit

        public ConsultantDo ConsultantEdit(int Id)
        {
            ConsultantDo consultantDo = new ConsultantDo();


            SqlCommand cmd = new SqlCommand("Select * from bookapp where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    consultantDo.Id = Convert.ToInt32(reader["Id"]);
                    consultantDo.PatientName = reader["PatientName"].ToString();
                    consultantDo.DoctorName = reader["DoctorName"].ToString();
                    consultantDo.Date = reader["Date"].ToString();
                    consultantDo.Problem = reader["Problem"].ToString();
                    consultantDo.Description = reader["Description"].ToString();
                    consultantDo.Address = reader["Address"].ToString();
                    consultantDo.Status = reader["Status"].ToString();



                }
                reader.Close();
                con.Close();

            }
            return consultantDo;
        }

        //outpatient delete

        public List<ConsultantDo> ConsultantDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from bookapp where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<ConsultantDo> consultantDos = new List<ConsultantDo>();

            con.Open();
            cmd = new SqlCommand("select * from bookapp", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ConsultantDo consultantDo = new ConsultantDo();

                consultantDo.Id = Convert.ToInt32(reader["Id"]);
                consultantDo.PatientName = reader["PatientName"].ToString();
                consultantDo.DoctorName = reader["DoctorName"].ToString();
                consultantDo.Date = reader["Date"].ToString();
                consultantDo.Problem = reader["Problem"].ToString();
                consultantDo.Description = reader["Description"].ToString();
                consultantDo.Address = reader["Address"].ToString();
                consultantDo.Status = reader["Status"].ToString();


                consultantDos.Add(consultantDo);

            }

            reader.Close();
            con.Close();
            return consultantDos;
        }

    }
}