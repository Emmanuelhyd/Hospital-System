using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Reflection;

namespace Hospital_System.Controllers
{
    public class PrescriptionController : Controller
    {
        DoctorBAL doctorBAL = new DoctorBAL();

        // GET: Prescription
        public ActionResult PrecList()
        {
            
            var mPrescription = doctorBAL.GetPrecList();
            return View(mPrescription);

        }
    }
}