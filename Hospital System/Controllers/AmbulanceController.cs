using Hospital_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class AmbulanceController : Controller
    {

        AmbulanceBAL ambulanceBAL= new AmbulanceBAL();
        // GET: Ambulance
        public ActionResult Ambulance()
        {
            var ambulance= ambulanceBAL.GetAmbulanceDetails();
            return View(ambulance);
        }
    }
}