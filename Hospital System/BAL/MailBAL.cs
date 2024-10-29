using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class MailBAL
    {
        MailDAL mailDAL = new MailDAL();


        //public string SendMail(Gmail gmail)
        //{
        //    return mailDAL.SendMail(gmail);
        //}


        public string Login(Gmail gmail)
        {
            return mailDAL.Login(gmail);
        }

        public void SendOTPtoMail(string Email, string OTP)
        {
             mailDAL.SendOTPtoMail(Email,OTP);
        }
    }
}