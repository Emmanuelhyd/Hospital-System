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
    public class FeedbackAdDAL
    {
        string _connectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public FeedbackAdDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }

        //List
        public List<FeedbackDo> FeedbackListAdmin()
        {
            List<FeedbackDo> feedbackDos = new List<FeedbackDo>();

            {

                con.Open();
                cmd = new SqlCommand("select * from Feedback", con);
                SqlDataReader sdr;
                sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                foreach (DataRow row in dt.Rows)
                    feedbackDos.Add(
                        new FeedbackDo
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

                return feedbackDos;
            }
        }

        //Add Feedback

        public List<FeedbackDo> AddFeedbackAd(FeedbackDo feedbackDo)
        {

            var ids = 0;
            con.Open();
            cmd = new SqlCommand("select * from Feedback where Id='" + feedbackDo.Id + "'", con);
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
                cmd = new SqlCommand("insert into Feedback(Id,Name,Age,Email,phoneNumber,Feedback,Doctor,Staff,Cleaning,Review) values(" + feedbackDo.Id + ",'" + feedbackDo.Name + "','" + feedbackDo.Age + "','" + feedbackDo.Email + "','" + feedbackDo.phoneNumber + "','" + feedbackDo.Feedback + "','" + feedbackDo.Doctor + "','" + feedbackDo.Staff + "','" + feedbackDo.Cleaning + "','" + feedbackDo.Review + "')", con);

            }
            else
            {
                cmd = new SqlCommand("update Feedback set Name='" + feedbackDo.Name + "',Age='" + feedbackDo.Age + "',Email='" + feedbackDo.Email + "',phoneNumber='" + feedbackDo.phoneNumber + "',Feedback='" + feedbackDo.Feedback + "',Doctor='" + feedbackDo.Doctor + "',Staff='" + feedbackDo.Staff + "',Cleaning='" + feedbackDo.Cleaning + "',Review='" + feedbackDo.Review + "' where Id=" + feedbackDo.Id + "", con);
            }
            cmd.ExecuteNonQuery();
            con.Close();


            List<FeedbackDo> feedbackDos = new List<FeedbackDo>();
            feedbackDos = FeedbackListAdmin();
            return feedbackDos;
        }

        //Auto increment Id
        public int FeedbackId()
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


        //Feedback Edit

        public FeedbackDo FeedbackEdit(int Id)
        {
            FeedbackDo feedbackDo = new FeedbackDo();


            SqlCommand cmd = new SqlCommand("Select * from Feedback where Id='" + Id + "'", con);
            {

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    feedbackDo.Id = Convert.ToInt32(reader["Id"]);
                    feedbackDo.Name = reader["Name"].ToString();
                    feedbackDo.Age = reader["Age"].ToString();
                    feedbackDo.Email = reader["Email"].ToString();
                    feedbackDo.phoneNumber = reader["phoneNumber"].ToString();
                    feedbackDo.Feedback = reader["Feedback"].ToString();
                    feedbackDo.Doctor = reader["Doctor"].ToString();
                    feedbackDo.Staff = reader["Staff"].ToString();
                    feedbackDo.Cleaning = reader["Cleaning"].ToString();
                    feedbackDo.Review = reader["Review"].ToString();
                   



                }
                reader.Close();
                con.Close();

            }
            return feedbackDo;
        }

        //outpatient delete

        public List<FeedbackDo> FeedbackDelete(int Id)
        {
            con.Open();
            cmd = new SqlCommand("Delete from Feedback where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();

            List<FeedbackDo> feedbackDos = new List<FeedbackDo>();

            con.Open();
            cmd = new SqlCommand("select * from Feedback", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FeedbackDo feedbackDo = new FeedbackDo();

                feedbackDo.Id = Convert.ToInt32(reader["Id"]);
                feedbackDo.Name = reader["Name"].ToString();
                feedbackDo.Age = reader["Age"].ToString();
                feedbackDo.Email = reader["Email"].ToString();
                feedbackDo.phoneNumber = reader["phoneNumber"].ToString();
                feedbackDo.Feedback = reader["Feedback"].ToString();
                feedbackDo.Doctor = reader["Doctor"].ToString();
                feedbackDo.Staff = reader["Staff"].ToString();
                feedbackDo.Cleaning = reader["Cleaning"].ToString();
                feedbackDo.Review = reader["Review"].ToString();



                feedbackDos.Add(feedbackDo);

            }

            reader.Close();
            con.Close();
            return feedbackDos;
        }

    }
}