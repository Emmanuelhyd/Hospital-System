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
    public class AppointmentAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: AppointmentAd
        public ActionResult AppointmentList(string app)
        {
            MAppointmentAd mAppointmentAd1 = new MAppointmentAd();
            List<MAppointmentAd> mAppointmentAd = new List<MAppointmentAd>();

            mAppointmentAd = adminBAL.AppointmentList(app);
            return View(mAppointmentAd);
        }

        //add Appointment
        public ActionResult AddAppointmentAd(MAppointmentAd mAppointmentAd)
        {
            var ids = 0;
            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();
            if (mAppointmentAd.Id != 0)
            {
                mAppointmentAds = adminBAL.AddAppointmentAd(mAppointmentAd);
            }
            if (mAppointmentAds.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mAppointmentAd.Id == 0)
                {
                    ids = adminDAL.AppointmentId();
                }
                mAppointmentAd.Id = ids + 1;

                return View(mAppointmentAd);
            }
            else
            {
                return RedirectToAction("AppointmentList", mAppointmentAds);
            }

        }

        //edit Appointment

        public ActionResult AppointmentEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MAppointmentAd mAppointmentAd = new MAppointmentAd();
            mAppointmentAd = adminBAL.AppointmentEdit(Id);
            if (mAppointmentAd.Id != 0)
            {
               
                return View("AddAppointmentAd", mAppointmentAd);
            }
            else
            {
                return RedirectToAction("AppointmentList", "AppointmentAd");

            }
          
        }

        public ActionResult AppointmentAdDelete(int Id)
        {
            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();

            mAppointmentAds = adminBAL.AppointmentAdDelete(Id);
            return RedirectToAction("AppointmentList", "AppointmentAd");
        }
    }
}