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
            return View(mShedule);
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

                return View(mShedule);
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
            if (mShedule.Id != 0)
            {

                return View("AddSheduleAd", mShedule);
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