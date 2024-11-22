using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using Hospital_System.Viewmodel;


namespace Hospital_System.Controllers
{
    public class ReceptionController : Controller
    {
        PatientBAL patientBAL = new PatientBAL();
        // GET: Reception
        public ActionResult Reception()
        {
            var doctor = patientBAL.GetDoctors();
            var model = new Allview
            {

                Doctors = doctor
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View(new Patients());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(Patients patients)
        {
            if (!ModelState.IsValid)
            {
                string res = patientBAL.Insertprofile(patients);
                if (res == "1")
                {
                    Session["FirstName"] = patients.FirstName;
                    Session["LastName"] = patients.LastName;

                    Session["PhoneNo"] = patients.PhoneNo;


                    TempData["result"] = "Registered";
                    return RedirectToAction("Login");
                }
            }



            TempData["result"] = "Enter All the details";


            return View(patients);
        }

    }
}