using Hospital_System.BAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class InpatientController : Controller
    {
        InPatientBAL inpatientBal= new InPatientBAL();
        // GET: Inpatient
        public ActionResult Inpatient()
        {
            var model = inpatientBal.HospPatients();
            return View (model);
        }
       


        public ActionResult GetHospPatient(int Id)
        {
            HospPatient hospPatient = inpatientBal.GetHospPatient(Id);
           if(hospPatient== null)
           
            {
                return RedirectToAction("Reception");
            }

            return View(hospPatient);
        }


        public ActionResult DoctorsList()
        {
            var model = inpatientBal.GetDoctors();
            return View(model);
        }
    }
}