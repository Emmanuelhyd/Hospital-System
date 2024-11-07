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
using Hospital_System.Dash;
using System.Web.UI.WebControls;

namespace Hospital_System.Controllers
{
    public class AmbulanceAdController : Controller
    {MenuBAL menuBAL = new MenuBAL();
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: AmbulanceAd
        public ActionResult AmbulanceListAd(string Driver)
        {
            MAmbulance mAmbulances = new MAmbulance();
            List<MAmbulance> mAmbulance = new List<MAmbulance>();

            mAmbulance = adminBAL.AmbulanceListAd(Driver);

            var menu = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mAmbulances = mAmbulance
            };
           
            return View(menu);
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
            else if(mAmbulances.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mAmbulance.Id == 0)
                {
                    ids = adminDAL.AmbulanceAdId();
                }
                mAmbulance.Id = ids + 1;

                var ambulance = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    mAmbulance = mAmbulance
                };




                return View(ambulance);
            }
           
            
                return RedirectToAction("AmbulanceListAd", mAmbulances);
               
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

            var ambulance = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mAmbulance = mAmbulance
            };



            if (mAmbulance.Id != 0)
            {

                return View("AddAmbulanceAd", ambulance);
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

            var model = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mAmbulance = mAmbulance
            };

            return PartialView("_Ambulance", model);


        }

        //driver List
        public ActionResult AmbulanceDriverAd(string Driver)
        {
            MDriverAd mDriverS = new MDriverAd();
            List<MDriverAd> mDriverAd = new List<MDriverAd>();

            mDriverAd = adminBAL.AmbulanceDriverAd(Driver);

            var driver = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mDriverAds= mDriverAd
            };
            return View(driver);
        }
       


        public ActionResult AddDriverAd(MDriverAd mDriverAd)
        {
            var ids = 0;

            List<MDriverAd> mDriverAds = new List<MDriverAd>();


            if (mDriverAd.Id != 0)
            {
                mDriverAds = adminBAL.AddDriverAd(mDriverAd);
            }
            else if (mDriverAds.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mDriverAd.Id == 0)
                {
                    ids = adminDAL.DynamicId();
                }
                mDriverAd.Id = ids + 1;
                var drivers = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    MDriverAd = mDriverAd
                };

                return View(drivers);
            }


            return RedirectToAction("AmbulanceDriverAd", mDriverAds);



            //return View(mDriver);
        }
        //driver edit
        public ActionResult DriverEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MDriverAd mDriver = new MDriverAd();
            mDriver = adminBAL.DriverEdit(Id);

            var drivers = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                MDriverAd = mDriver
            };

            if (mDriver.Id != 0)
            {

                return View("AddDriverAd", drivers);
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

        public ActionResult Ambulancedriver(int Id)
        {

            MDriverAd mDriver = adminBAL.Ambulancedriver(Id);

            if (mDriver == null)
            {
                return HttpNotFound("ID not found");
            }

            var driver = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                MDriverAd = mDriver
            };

            return PartialView("_Ambulancedriver", driver);


        }


    }
}