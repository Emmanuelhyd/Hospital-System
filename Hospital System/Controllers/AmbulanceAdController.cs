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
    public class AmbulanceAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: AmbulanceAd
        public ActionResult AmbulanceListAd()
        {
            MAmbulance mAmbulances = new MAmbulance();
            List<MAmbulance> mAmbulance = new List<MAmbulance>();

            mAmbulance = adminBAL.AmbulanceListAd();
            return View(mAmbulance);
        }



        //[HttpGet]
        //public ActionResult AddAmbulanceAd()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddAmbulanceAd(MAmbulance mAmbulance)
        {
            var ids = 0;

            List<MAmbulance> mAmbulances = new List<MAmbulance>();


            if (mAmbulance.Id != 0)
            {
                mAmbulances = adminBAL.AddAmbulanceAd(mAmbulance);
            }
            if (mAmbulances.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mAmbulance.Id == 0)
                {
                    ids = adminDAL.AmbulanceAdId();
                }
                mAmbulance.Id = ids + 1;

                return View(mAmbulance);
            }
            else
            {
                return RedirectToAction("AmbulanceListAd", mAmbulances);
            }


            
        }

        //Ambulance ststus

    //    private IEnumerable<SelectListItem> GetAmbulaceStatus()
    //    {
    //        return new List<SelectListItem>
    //{
    //    new SelectListItem { Value = "Active", Text = "Active" },
    //    new SelectListItem { Value = "InActive", Text = "InAtive" }
        
    //};
    //    }


        //edit Ambulance

        public ActionResult AmbulanceEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MAmbulance mAmbulance = new MAmbulance();
            mAmbulance = adminBAL.AmbulanceEdit(Id);
            if (mAmbulance.Id != 0)
            {

                return View("AddAmbulanceAd", mAmbulance);
            }
            else
            {
                return RedirectToAction("AmbulanceListAd", "AMbulanceAd");

            }
        }

        //Delete Ambulance
        public ActionResult AmbulanceDelete(int Id)
        {
            List<MAmbulance> mAmbulances = new List<MAmbulance>();

            mAmbulances = adminBAL.AmbulanceDelete(Id);
            return RedirectToAction("AmbulanceListAd", "AmbulanceAd");
        }

        //ambulance View
        public ActionResult Ambulance(int Id)
        {

            MAmbulance mAmbulance = adminBAL.Ambulance(Id);

            if (mAmbulance == null)
            {
                return HttpNotFound("ID not found");
            }

            return PartialView("_Ambulance", mAmbulance);


        }

        //driver List
        public ActionResult AmbulanceDriverAd(string Driver)
        {
            MDriverAd mDriverS = new MDriverAd();
            List<MDriverAd> mDriverAd = new List<MDriverAd>();

            mDriverAd = adminBAL.AmbulanceDriverAd(Driver);
            return View(mDriverAd);
        }
        //Add driver
        //[HttpPost]
        
        public ActionResult AddDriverAd(MDriverAd mDriver)
        {
            var ids = 0;

            List<MDriverAd> mDriverAds = new List<MDriverAd>();
            

            if (mDriver.Id != 0)
            {
                mDriverAds = adminBAL.AddDriverAd(mDriver);
            }
            if (mDriverAds.Count == 0)
                {
                adminDAL = new AdminDAL();
                if (mDriver.Id == 0)
                {
                    ids = adminDAL.DynamicId();
                }
                mDriver.Id = ids+1;

                return View(mDriver);
                }
                else
                {
                    return RedirectToAction("AmbulanceDriverAd", mDriverAds);
                }
           

            //return View(mDriver);
        }
        //driver edit
        public ActionResult DriverEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MDriverAd mDriver = new MDriverAd();
            mDriver = adminBAL.DriverEdit(Id);
            if (mDriver.Id != 0)
            {

                return View("AddDriverAd", mDriver);
            }
            else
            {
                return RedirectToAction("AmbulanceDriverAd", "AmbulanceAd");

            }
        }

        //driver delete

        public ActionResult DriverDelete(int Id)
        {
            List<MDriverAd> mDriverAds = new List<MDriverAd>();

            mDriverAds = adminBAL.DriverDelete(Id);
            return RedirectToAction("AmbulanceDriverAd", "AmbulanceAd");
        }

        // view driver details

        public ActionResult Ambulancedriver( int Id)
            {
           
                MDriverAd mDriver = adminBAL.Ambulancedriver(Id);

                if (mDriver == null)
                {
                    return HttpNotFound("ID not found");
                }

                return PartialView("_Ambulancedriver", mDriver);

            
        }


    }
}