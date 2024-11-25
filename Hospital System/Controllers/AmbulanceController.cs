using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
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

        public ActionResult AddAmbulance(AmbulanceDetails ambulanceDo)
        {
            var ids = 0;

            List<AmbulanceDetails> ambulanceDos = new List<AmbulanceDetails>();


            if (ambulanceDo.Id != 0)
            {
                ambulanceDos = ambulanceBAL.AddAmbulance(ambulanceDo);
            }
            if (ambulanceDos.Count == 0)
            {
             AmbulanceDAL   ambulanceRDAL = new AmbulanceDAL();
                if (ambulanceDo.Id == 0)
                {
                    ids = ambulanceRDAL.AmbId();
                }
                ambulanceDo.Id = ids + 1;

                return View(ambulanceDo);
            }
            else
            {
                return RedirectToAction("Ambulance", ambulanceDo);
            }


        }

        //Ambulance Edit

        public ActionResult AmbE(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            AmbulanceDetails ambulanceDo = new AmbulanceDetails();

            ambulanceDo = ambulanceBAL.AmbE(Id);
            if (ambulanceDo.Id != 0)
            {

                return View("AddAmbulance", ambulanceDo);
            }
            else
            {
                return RedirectToAction("Ambulance", "Amulance");

            }
        }


        public ActionResult AmbulanceId(int Id)
        {
            var Ambulance = ambulanceBAL.AmbulanceId(Id);
            if (Ambulance == null)
            {
                return HttpNotFound("ID not found");
            }
            return View(Ambulance);

        }
    }
}