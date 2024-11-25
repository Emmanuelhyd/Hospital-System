using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class AttendDAL
    {
        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;



        public AttendDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        public List<Attend> AttendanceDetails()
        {
            List<Attend>attends = new List<Attend>();
            con.Open();
            cmd = new SqlCommand("select * from attendance",con);
            reader= cmd.ExecuteReader();
            while(reader.Read())
            {
                Attend attend = new Attend();

                attend.Id = Convert.ToInt32(reader["Id"]);
                attend.Name = reader.GetString(reader.GetOrdinal("Name"));
                attend.Department = reader.GetString(reader.GetOrdinal("Department"));
                attend.JobTitle = reader.GetString(reader.GetOrdinal("JobTitle"));
                attend.Contact = reader.GetString(reader.GetOrdinal("contact"));
                attend.Shift = reader.GetString(reader.GetOrdinal("Shift"));
                attend.Time = reader.GetString(reader.GetOrdinal("Time"));
                attend.LoginTime = reader.GetString(reader.GetOrdinal("LoginTime"));
                attend.LogoutTime = reader.GetString(reader.GetOrdinal("LogoutTime"));
                attend.Status = reader.GetString(reader.GetOrdinal("Status"));

                attends.Add(attend);

            }

            reader.Close();
            con.Close();
            return attends;

        }



        public List<Attend> AddAttend(Attend attendanceDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Attendance where Id='" + attendanceDo.Id + "'", con);
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
                cmd = new SqlCommand("insert into Attendance(Id,Name,Department,JobTitle,Contact,Shift,Time,LoginTime,LogoutTime,Status) values(" + attendanceDo.Id + ",'" + attendanceDo.Name + "','" + attendanceDo.Department + "','" + attendanceDo.JobTitle + "','" + attendanceDo.Contact + "','" + attendanceDo.Shift + "','" + attendanceDo.Time + "','" + attendanceDo.LoginTime + "','" + attendanceDo.LogoutTime + "','" + attendanceDo.Status + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Attendance set Name='" + attendanceDo.Name + "',Department='" + attendanceDo.Department + "',JobTitle='" + attendanceDo.JobTitle + "',Contact='" + attendanceDo.Contact + "',Shift='" + attendanceDo.Shift + "',Time='" + attendanceDo.Time + "',LoginTime='" + attendanceDo.LoginTime + "',LogoutTime='" + attendanceDo.LogoutTime + "',Status='" + attendanceDo.Status + "' where Id=" + attendanceDo.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<Attend> attendanceDos = new List<Attend>();
            attendanceDos = AttendanceDetails();
            return attendanceDos;
        }

        //Auto increment Id
        public int AttendanceId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM Attendance", con);
            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                id = Convert.ToInt32(result);
            }
            con.Close();
            return id;
        }

        //Attendance Edit

        public Attend AttendanceE(int Id)
        {
            Attend attendanceDo = new Attend();


            SqlCommand cmd = new SqlCommand("Select * from Attendance where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    attendanceDo.Id = Convert.ToInt32(reader["Id"]);
                    attendanceDo.Name = reader["Name"].ToString();
                    attendanceDo.Department = reader["Department"].ToString();
                    attendanceDo.JobTitle = reader["JobTitle"].ToString();
                    attendanceDo.Contact = reader["Contact"].ToString();

                    attendanceDo.Shift = reader["Shift"].ToString();
                    attendanceDo.Time = reader["Time"].ToString();
                    attendanceDo.LoginTime = reader["LoginTime"].ToString();
                    attendanceDo.LogoutTime = reader["LogoutTime"].ToString();
                    attendanceDo.Status = reader["Status"].ToString();



                }
                reader.Close();
                con.Close();

            }
            return attendanceDo;
        }


        public Attend AttendId(int Id)
        {
            Attend attendanceDo = new Attend();


            SqlCommand cmd = new SqlCommand("Select * from Attendance where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    attendanceDo.Id = Convert.ToInt32(reader["Id"]);
                    attendanceDo.Name = reader["Name"].ToString();
                    attendanceDo.Department = reader["Department"].ToString();
                    attendanceDo.JobTitle = reader["JobTitle"].ToString();
                    attendanceDo.Contact = reader["Contact"].ToString();

                    attendanceDo.Shift = reader["Shift"].ToString();
                    attendanceDo.Time = reader["Time"].ToString();
                    attendanceDo.LoginTime = reader["LoginTime"].ToString();
                    attendanceDo.LogoutTime = reader["LogoutTime"].ToString();
                    attendanceDo.Status = reader["Status"].ToString();



                }
                reader.Close();
                con.Close();

            }
            return attendanceDo;

        }

    }
}