using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;
using Hospital_System.Models;
using AdminPages.Models;
using Hospital_System.Dash;


namespace Hospital_System.Controllers
{
    public class SheduleAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: SheduleAd
        public ActionResult SheduleList(string Shedule)
        {
            MShedule mShedule1 = new MShedule();
            List<MShedule> mShedule = new List<MShedule>();

            mShedule = adminBAL.SheduleList(Shedule);

            var schedule = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mShedules= mShedule

            };
            
            return View(schedule);
        }

       

       
        public ActionResult AddSheduleAd(MShedule mShedule)
        {
            var ids = 0;

            List<MShedule> mShedules = new List<MShedule>();


            if (mShedule.Id != 0)
            {
                mShedules = adminBAL.AddSheduleAd(mShedule);
            }
            if (mShedules.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mShedule.Id == 0)
                {
                    ids = adminDAL.SheduleId();
                }
                mShedule.Id = ids + 1;

                var schedule = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    MShedule = mShedule

                };

                return View(schedule);

            }
            else
            {
                return RedirectToAction("SheduleList", mShedules);
            }


            //var ids = 0;

            //List<MShedule> mShedules = new List<MShedule>();


            //if (mShedule.Id != 0)
            //{
            //    mShedules = adminBAL.AddSheduleAd(mShedule);
            //}
            //if (mShedules.Count == 0)
            //{
            //    adminDAL = new AdminDAL();
            //    if (mShedule.Id == 0)
            //    {
            //        ids = adminDAL.SheduleId();
            //    }
            //    mShedule.Id = ids + 1;

            //    return View(mShedule);
            //}
            //else
            //{
            //    return RedirectToAction("SheduleList", mShedules);
            //}

        }

        public ActionResult SLEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MShedule mShedule = new MShedule();
            mShedule = adminBAL.SLEdit(Id);

            var schedule = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                MShedule = mShedule

            };


            if (mShedule.Id != 0)
            {

                return View("AddSheduleAd", schedule);
            }
            else
            {
                return RedirectToAction("SheduleList", "SheduleAd");

            }
        }

        public ActionResult SheduleDelete(int Id)
        {
            List<MShedule> mShedules = new List<MShedule>();

            mShedules = adminBAL.SheduleDelete(Id);
            return RedirectToAction("SheduleList", "SheduleAd");
        }
    }
}