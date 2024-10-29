using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using Hospital_System.Models;


namespace Hospital_System.DAL
{
    public class MailDAL
    {
        string _connectionString = null;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;



        public MailDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            con = new SqlConnection(_connectionString);
        }


        public string Login(Gmail gmail)
        {
            string res = " ";
            con.Open();
            var sqlq = "select   UserName, Password,Email from profiles where UserName='" + gmail.UserName + "' and Password='" + gmail.Password + "'";
            cmd = new SqlCommand(sqlq, con);
            reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                
                string UserName = reader.GetString(reader.GetOrdinal("UserName"));
                string Password = reader.GetString(reader.GetOrdinal("Password"));
                string Email = reader.GetString(reader.GetOrdinal("Email"));


                if (gmail.UserName == UserName && gmail.Password == Password)
                {

                    res = "success";

                    gmail.Email = Email;
                }
                else
                {
                    res = "Invalid UserName or Password";
                }


            }
            reader.Close();
            con.Close();
            return res;
        }

        public  void SendOTPtoMail(string Email, string OTP)
        {
            var subject = " Your One Time Password Code ";
            var Body = $" Your OTP code is:{OTP}." +
                $" It is valid for 5 minutes. " +
                       $"Please do not reply";
            con.Open();

            MailMessage mail = new MailMessage();
           
            mail.From = new MailAddress("softwares910@gmail.com");
            mail.To.Add(Email);
            mail.Subject = subject;
            mail.Body = Body;

            var smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("softwares910@gmail.com", "hmnr gpko jlsr advg");
            smtp.Send(mail);
            con.Close();
        }

       


    }
}