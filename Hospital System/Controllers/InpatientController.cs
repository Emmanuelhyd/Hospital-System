using Hospital_System.BAL;
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
    }
}