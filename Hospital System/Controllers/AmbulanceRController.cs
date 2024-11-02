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
    public class AmbulanceRController : Controller
    {
        AmbulanceRBAL ambulanceRBAL=new AmbulanceRBAL();
        AmbulanceRDAL ambulanceRDAL;
        // GET: AmbulanceR
        public ActionResult AmbList()
        {
            AmbulanceDo ambulanceDo = new AmbulanceDo();
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            ambulanceDos = ambulanceRBAL.AmbList();
            return View(ambulanceDos);
        }

        public ActionResult AddAmb(AmbulanceDo ambulanceDo)
        {
            var ids = 0;

            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();


            if (ambulanceDo.Id != 0)
            {
                ambulanceDos = ambulanceRBAL.AddAmb(ambulanceDo);
            }
            if (ambulanceDos.Count == 0)
            {
                ambulanceRDAL = new AmbulanceRDAL();
                if (ambulanceDo.Id == 0)
                {
                    ids = ambulanceRDAL.AmbId();
                }
                ambulanceDo.Id = ids + 1;

                return View(ambulanceDo);
            }
            else
            {
                return RedirectToAction("AmbList", ambulanceDo);
            }


        }

        //Inpatient Edit

        public ActionResult AmbEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            AmbulanceDo ambulanceDo = new AmbulanceDo();

            ambulanceDo = ambulanceRBAL.AmbEdit(Id);
            if (ambulanceDo.Id != 0)
            {

                return View("AddAmb", ambulanceDo);
            }
            else
            {
                return RedirectToAction("AmbList", "AmulanceR");

            }
        }

        //Inpatient Delete

        public ActionResult AmbDelete(int Id)
        {
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            ambulanceDos = ambulanceRBAL.AmbDelete(Id);
            return RedirectToAction("AmbList", "AmbulanceR");
        }
    }
}