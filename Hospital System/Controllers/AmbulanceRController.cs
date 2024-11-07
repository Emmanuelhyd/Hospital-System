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
        public ActionResult AmbList(string And)
        {
            AmbulanceDo ambulanceDo = new AmbulanceDo();
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            ambulanceDos = ambulanceRBAL.AmbList(And);
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

        //Ambulance Edit

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

        //Ambulance Delete

        public ActionResult AmbDelete(int Id)
        {
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();

            ambulanceDos = ambulanceRBAL.AmbDelete(Id);
            return RedirectToAction("AmbList", "AmbulanceR");
        }



        //Driver List
        public ActionResult DriveList(string Dri)
        {
            DriverDo driverDo = new DriverDo();
            List<DriverDo> driverDos = new List<DriverDo>();

            driverDos = ambulanceRBAL.DriveList(Dri);
            return View(driverDos);
        }

        //add driver
        public ActionResult AddDrive(DriverDo driverDo)
        {
            var ids = 0;

            List<DriverDo> driverDos = new List<DriverDo>();


            if (driverDo.Id != 0)
            {
                driverDos = ambulanceRBAL.AddDrive(driverDo);
            }
            if (driverDos.Count == 0)
            {
                ambulanceRDAL = new AmbulanceRDAL();
                if (driverDo.Id == 0)
                {
                    ids = ambulanceRDAL.DriverRId();
                }
                driverDo.Id = ids + 1;

                return View(driverDo);
            }
            else
            {
                return RedirectToAction("DriveList", driverDo);
            }


        }

        //Driver Edit

        public ActionResult DriveREdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            DriverDo driverDo = new DriverDo();

            driverDo = ambulanceRBAL.DriveREdit(Id);
            if (driverDo.Id != 0)
            {

                return View("AddDrive", driverDo);
            }
            else
            {
                return RedirectToAction("DriveList", "AmulanceR");

            }
        }


        //Driver Delete

        public ActionResult DriveRDelete(int Id)
        {
            List<DriverDo> driverDos = new List<DriverDo>();

            driverDos = ambulanceRBAL.DriveRDelete(Id);
            return RedirectToAction("DriveList", "AmbulanceR");
        }

    }
}