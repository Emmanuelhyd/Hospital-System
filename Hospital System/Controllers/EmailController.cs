using Hospital_System.BAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hospital_System.DAL;

namespace Hospital_System.Controllers
{
    public class EmailController : Controller
    {

        MailBAL mailBAL = new MailBAL();
        // GET: Mail



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(Gmail gmail)
        {
            string res = mailBAL.Login(gmail);

            if (res == "success")
            {
                Session["UserName"] = gmail.UserName;
                Session["PatientId"] = gmail.PatientId;

                string Otp = GenerateOTP();
                Session["GenerateOTP"] = Otp;
                mailBAL.SendOTPtoMail(gmail.Email, Otp);
                

                return RedirectToAction("VerifyOTP");
            }
            else
            {
                TempData["InValid"] = "Invalid UserName or Password";
                return View();
            }

        }

        private string GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(10000, 100000).ToString();
        }
        [HttpGet]
        public ActionResult VerifyOTP()
        {
            return View();

        }
        [HttpPost]

        public ActionResult VerifyOTP(string userEnteredOTP)
        {
            string generate = Session["GenerateOTP"].ToString();

            if (generate == userEnteredOTP)
            {
                return RedirectToAction("Reception","Reception");
            }

            TempData["Message"] = "OTP does not match";
            return View();

        }
    }
}
