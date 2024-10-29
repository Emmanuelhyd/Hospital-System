using Hospital_System.BAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class ConsultController : Controller
    {
        ConsultBAL consultBAL= new ConsultBAL();
        // GET: Consult
        public ActionResult Consult()
        {
            var model = consultBAL.CHospPatient();
           
            return View(model);
        }

        public ActionResult ConsultDoc( string DoctorName)
        {
            List<HospPatient> hospPatients = consultBAL.ConsultDoc(DoctorName);
            if (hospPatients == null )
            {
                TempData["Message"] = "No patients found for this doctor.";
                return RedirectToAction("Consult");
            }

            return View(hospPatients); 
        }

    }
 }
