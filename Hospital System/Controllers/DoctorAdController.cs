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
using AdminPages.Models;

namespace Hospital_System.Controllers
{
    public class DoctorAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: Doctor
        public ActionResult DoctorListAd(string doc)
        {
            MDoctorAd mDoctor1 = new MDoctorAd();
            List<MDoctorAd> mDoctors = new List<MDoctorAd>();

            mDoctors = adminBAL.DoctorListAd(doc);

            var doctor = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mDoctorAds = mDoctors

            };


            return View(doctor);
        }


        //[HttpGet]
        //public ActionResult AddDoctorAd()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddDoctorAd(MDoctorAd mDoctorAd)
        {

            var ids = 0;

            List<MDoctorAd> mDoctors = new List<MDoctorAd>();


            if (mDoctorAd.DoctorId != 0)
            {
                mDoctors = adminBAL.AddDoctorAd(mDoctorAd);
            }
            else
            {
                adminDAL = new AdminDAL();
                if (mDoctorAd.DoctorId == 0)
                {
                    ids = adminDAL.DoctorId();
                }
                mDoctorAd.DoctorId = ids + 1;
                var doctor = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    MDoctorAd = mDoctorAd

                };



                return View(doctor);
            }


            return RedirectToAction("DoctorListAd", mDoctors);

        }

        public ActionResult DAEdit(int DoctorId)
        {
            if (DoctorId <= 0)
                return HttpNotFound();

            MDoctorAd mDoctor = new MDoctorAd();
            mDoctor = adminBAL.DAEdit(DoctorId);

            var doctor = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                MDoctorAd = mDoctor

            };


            if (mDoctor.DoctorId != 0)
            {

                return View("AddDoctorAd", doctor);
            }
            else
            {
                return RedirectToAction("DoctorListAd", "DoctorAd");

            }
        }

        public ActionResult DADelete(int DoctorId)
        {
            List<MDoctorAd> mDoctors = new List<MDoctorAd>();

            mDoctors = adminBAL.DADelete(DoctorId);


            return RedirectToAction("DoctorListAd", "DoctorAd");
        }

    }

}