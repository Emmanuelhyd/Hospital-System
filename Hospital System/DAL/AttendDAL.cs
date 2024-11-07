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
    }
}