using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hospital_System.DAL
{
    public class FeedDAL
    {

        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        public FeedDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        public string Feed(Feedbk feedbk)
        {
            string res = "";
            con.Open();
            cmd = new SqlCommand("insert into  feedback(Name,Age,Email,PhoneNumber,Waitingroom,Staff,Nurse,Doctor,OverallExperience) values('" + feedbk.Name + "','" + feedbk.Age + "','" + feedbk.Email + "','" + feedbk.PhoneNumber + "'" +
                "," + feedbk.Waitingroom + "," + feedbk.Staff + "," + feedbk.Nurse + "," + feedbk.Doctor + ",'" + feedbk.OverallExperience + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return "Feedback Sent";
        }

    }
}