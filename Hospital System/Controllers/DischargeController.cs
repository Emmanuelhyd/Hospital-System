using Hospital_System.BAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class DischargeController : Controller
    {
        DischargeBAL dischargeBAL= new DischargeBAL();
        // GET: Discharge
        public ActionResult Discharge(string date, int? patientId)
        {
            DateTime? selecteddate = null;
            if (!string.IsNullOrEmpty(date))
            {
                selecteddate = DateTime.Parse(date);
            }

            var model = dischargeBAL.GetdischargPatients(selecteddate, patientId);
            return View(model);

        }

        public ActionResult DischargeId(int PatientId)
        {
            DischargPatient dischargPatient = dischargeBAL.DischargeId(PatientId);
            if(dischargPatient== null)
            {
                return View("Discharge");
            }
            return View(dischargPatient);

        }
       

       
    }
}