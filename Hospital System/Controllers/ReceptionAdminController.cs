using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hospital_System.Models;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;
using Hospital_System.Viewmodel;

namespace Hospital_System.Controllers
{
    public class ReceptionAdminController : Controller
    {
        PatientBAL patientBAL = new PatientBAL();
        // GET: ReceptionAdmin
        public ActionResult ReceptionFrontPage()
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