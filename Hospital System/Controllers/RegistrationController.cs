using Hospital_System.BAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class RegistrationController : Controller
    {
        DoctorBAL doctorBAL = new DoctorBAL();

        // GET: Registration
        public ActionResult RegistrationPage()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult RegistrationPage(MRegistration mRegistration)
        {
            string res = doctorBAL.RegistrationPage(mRegistration);
            if (res.Contains("1"))
            {
                return Redirect("RegistrationPage");
            }
            else
            {
                return View();
            }
        }

       
    }
}