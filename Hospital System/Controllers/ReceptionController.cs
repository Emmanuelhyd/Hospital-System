﻿using System;
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



    }
}