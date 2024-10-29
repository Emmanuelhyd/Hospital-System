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

namespace Hospital_System.Controllers
{
    public class AmbulanceAdminController : Controller
    {
        AmbulanceAdDAL ambulanceAdDAL;
        AmbulanceAdBAL ambulanceAdBAL=new AmbulanceAdBAL();
        // GET: AmbulanceAdmin
        public ActionResult AmbulanceListAdmin()
        {
            AmbulanceDo ambulanceDo = new AmbulanceDo();
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            ambulanceDos = ambulanceAdBAL.AmbulanceListAdmin();
            return View(ambulanceDos);

        }

        //Add Ambulance Admin

        public ActionResult AddAmbulanceAdmin(AmbulanceDo ambulanceDo)
        {
            var ids = 0;

            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();


            if (ambulanceDo.Id != 0)
            {
                ambulanceDos = ambulanceAdBAL.AddAmbulanceAdmin(ambulanceDo);
            }
            if (ambulanceDos.Count == 0)
            {
                ambulanceAdDAL = new AmbulanceAdDAL();
                if (ambulanceDo.Id == 0)
                {
                    ids = ambulanceAdDAL.AmbulanceId();
                }
                ambulanceDo.Id = ids + 1;

                return View(ambulanceDo);
            }
            else
            {
                return RedirectToAction("AmbulanceListAdmin", ambulanceDo);
            }


        }

        //Inpatient Edit

        public ActionResult AmbulanceEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            AmbulanceDo ambulanceDo = new AmbulanceDo();

            ambulanceDo = ambulanceAdBAL.AmbulanceEdit(Id);
            if (ambulanceDo.Id != 0)
            {

                return View("AddAmbulanceAdmin", ambulanceDo);
            }
            else
            {
                return RedirectToAction("AmbulanceListAdmin", "AmulanceAdmin");

            }
        }

        //Inpatient Delete

        public ActionResult AmbulanceDelete(int Id)
        {
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            ambulanceDos = ambulanceAdBAL.AmbulanceDelete(Id);
            return RedirectToAction("AmbulanceListAdmin", "AmbulanceAdmin");
        }

    }
}