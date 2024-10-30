using Hospital_System.BAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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


        //Feedback List

        //List
        public List<Feedbk> FeedList()
        {
            List<Feedbk> feedbks = new List<Feedbk>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Feedback", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    feedbks.Add(
                        new Feedbk
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["Name"].ToString(),
                            Age = row["Age"].ToString(),
                            Email = row["Email"].ToString(),
                            phoneNumber = row["phoneNumber"].ToString(),
                            Feedback = row["Feedback"].ToString(),
                            Doctor = row["Doctor"].ToString(),
                            Staff = row["Staff"].ToString(),
                            Cleaning = row["Cleaning"].ToString(),
                            Review = row["Review"].ToString(),



                        });

                return feedbks;
            }
        }


        //Add Feedback

        public List<Feedbk> Feed(Feedbk feedbk)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Feedback where Id='" + feedbk.Id + "'", con);
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
                cmd = new SqlCommand("insert into Feedback(Id,Name,Age,Email,phoneNumber,Feedback,Doctor,Staff,Cleaning,Review) values(" + feedbk.Id + ",'" + feedbk.Name + "','" + feedbk.Age + "','" + feedbk.Email + "','" + feedbk.phoneNumber + "','" + feedbk.Feedback + "','" + feedbk.Doctor + "','" + feedbk.Staff + "','" + feedbk.Cleaning + "','" + feedbk.Review + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Feedback set Name='" + feedbk.Name + "',Age='" + feedbk.Age + "',Email='" + feedbk.Email + "',phoneNumber='" + feedbk.phoneNumber + "',Feedback='" + feedbk.Feedback + "',Doctor='" + feedbk.Doctor + "',Staff='" + feedbk.Staff + "',Cleaning='" + feedbk.Cleaning + "',Review='" + feedbk.Review + "' where Id=" + feedbk+ "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<Feedbk> feedbks = new List<Feedbk>();
            feedbks = FeedList();
            return feedbks;
        }



        public int FeedId()
        {
            int id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT MAX(Id) FROM Feedback", con);
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