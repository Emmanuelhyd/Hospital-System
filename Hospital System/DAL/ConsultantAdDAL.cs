using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Hospital_System.Models;
using System.Data;
using AdminPages.Models;

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
                cmd = new SqlCommand("select * from doctors", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    consultantDos.Add(
                        new ConsultantDo
                        {
                            DoctorId = Convert.ToInt32(row["DoctorId"]),
                            FullName = row["FullName"].ToString(),
                            //Firstname = row["Firstname"].ToString(),
                            //LastName = row["LastName"].ToString(),
                            Email = row["Email"].ToString(),
                            Department = row["Department"].ToString(),
                            Designation = row["Designation"].ToString(),
                            PhoneNo = row["PhoneNo"].ToString(),
                            ContactNo = row["ContactNo"].ToString(),
                            Education = row["Education"].ToString(),
                            Gender = row["Gender"].ToString(),
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
            cmd = new SqlCommand("select * from doctors where DoctorId='" + consultantDo.DoctorId + "'", con);
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                ids = Convert.ToInt32(reader["DoctorId"]);
            }

            reader.Close();
            con.Close();



            con.Open();
            if (ids == 0)
            {
                cmd = new SqlCommand("insert into doctors(DoctorId,FullName,Email,Department,Designation,PhoneNo,ContactNo,Education,Gender,Status) values(" + consultantDo.DoctorId + ",'" + consultantDo.FullName + "','" + consultantDo.Email + "','" + consultantDo.Department + "','" + consultantDo.Designation + "','" + consultantDo.PhoneNo + "','" + consultantDo.ContactNo + "','" + consultantDo.Education + "','" + consultantDo.Gender + "','" + consultantDo.Status + "')", con);
            }
            else
            {
                cmd = new SqlCommand("update doctors set FullName='" + consultantDo.FullName + "',Email='" + consultantDo.Email + "',Department='" + consultantDo.Department + "',Designation='" + consultantDo.Designation + "',PhoneNo='" + consultantDo.PhoneNo + "',ContactNo='" + consultantDo.ContactNo + "',Education='" + consultantDo.Education + "',Gender='" + consultantDo.Gender + "',Status='" + consultantDo.Status + "' where DoctorId=" + consultantDo.DoctorId + "", con);
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
            cmd = new SqlCommand("SELECT MAX(DoctorId) FROM doctors", con);
            var result = cmd.ExecuteScalar();
            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }


        //Attendance Edit

        public ConsultantDo ConsultantEdit(int DoctorId)
        {
            ConsultantDo consultantDo = new ConsultantDo();
            SqlCommand cmd = new SqlCommand("Select * from doctors where DoctorId='" + DoctorId + "'", con);
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    consultantDo.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                    consultantDo.FullName = reader["FullName"].ToString();
                    //consultantDo.Firstname = reader["Firstname"].ToString();
                    //consultantDo.LastName = reader["LastName"].ToString();
                    consultantDo.Email = reader["Email"].ToString();
                    consultantDo.Department = reader["Department"].ToString();
                    consultantDo.Designation = reader["Designation"].ToString();
                    consultantDo.PhoneNo = reader["PhoneNo"].ToString();
                    consultantDo.ContactNo = reader["ContactNo"].ToString();
                    consultantDo.Education = reader["Education"].ToString();
                    consultantDo.Gender = reader["Gender"].ToString();
                    consultantDo.Status = reader["Status"].ToString();
                }
                reader.Close();
                con.Close();
            }
            return consultantDo;
        }

        //outpatient delete

        public List<ConsultantDo> ConsultantDelete(int DoctorId)
        {
            con.Open();
            cmd = new SqlCommand("Delete from doctors where DoctorId='" + DoctorId + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            List<ConsultantDo> consultantDos = new List<ConsultantDo>();
            con.Open();
            cmd = new SqlCommand("select * from doctors", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ConsultantDo consultantDo = new ConsultantDo();

                consultantDo.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                consultantDo.FullName = reader["FullName"].ToString();
                //consultantDo.Firstname = reader["Firstname"].ToString();
                //consultantDo.LastName = reader["LastName"].ToString();
                consultantDo.Email = reader["Email"].ToString();
                consultantDo.Department = reader["Department"].ToString();
                consultantDo.Designation = reader["Designation"].ToString();
                consultantDo.PhoneNo = reader["PhoneNo"].ToString();
                consultantDo.ContactNo = reader["ContactNo"].ToString();
                consultantDo.Education = reader["Education"].ToString();
                consultantDo.Gender = reader["Gender"].ToString();
                consultantDo.Status = reader["Status"].ToString();
            }
            reader.Close();
            con.Close();
            return consultantDos;
        }

    }
}