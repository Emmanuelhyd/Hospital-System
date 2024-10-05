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
            return View(mDoctors);
        }


        //[HttpGet]
        //public ActionResult AddDoctorAd()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddDoctorAd(MDoctorAd mDoctor)
        {

            var ids = 0;

            List<MDoctorAd> mDoctors = new List<MDoctorAd>();


            if (mDoctor.DoctorId != 0)
            {
                mDoctors = adminBAL.AddDoctorAd(mDoctor);
            }
            if (mDoctors.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mDoctor.DoctorId == 0)
                {
                    ids = adminDAL.DoctorId();
                }
                mDoctor.DoctorId = ids + 1;

                return View(mDoctor);
            }
            else
            {
                return RedirectToAction("DoctorListAd", mDoctors);
            }
        }

        public ActionResult DAEdit(int DoctorId)
        {
            if (DoctorId <= 0)
                return HttpNotFound();

            MDoctorAd mDoctor = new MDoctorAd();
            mDoctor = adminBAL.DAEdit(DoctorId);
            if (mDoctor.DoctorId != 0)
            {

                return View("AddDoctorAd", mDoctor);
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