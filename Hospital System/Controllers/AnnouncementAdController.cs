using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Dash;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class AnnouncementAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: AnnouncementAd
        public ActionResult AnnouncementList(string announcement)
        {
            MAnnouncement mAnnouncement1 = new MAnnouncement();
            List<MAnnouncement> mAnnouncement = new List<MAnnouncement>();

            mAnnouncement = adminBAL.AnnouncementList(announcement);

            var Announce = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mAnnouncements = mAnnouncement
            };
            
            return View(Announce);
        }

       
        public ActionResult AddAnnouncementAd(MAnnouncement mAnnouncement)
        {
            var ids = 0;
            List<MAnnouncement> mAnnouncements = new List<MAnnouncement>();
            if (mAnnouncement.Id != 0)
            {
                mAnnouncements = adminBAL.AddAnnouncementAd(mAnnouncement);
            }
            if (mAnnouncements.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mAnnouncement.Id == 0)
                {
                    ids = adminDAL.AnnouncementId();
                }

              
                mAnnouncement.Id = ids + 1;
                var Announce = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    mAnnouncement = mAnnouncement
                };

                return View(Announce);
            }
            else
            {
                return RedirectToAction("AnnouncementList", mAnnouncements);
            }


        }

        public ActionResult ALEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();
            
            MAnnouncement mAnnouncement = new MAnnouncement();
            mAnnouncement = adminBAL.ALEdit(Id);

            var Announce = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mAnnouncement = mAnnouncement
            };



            if (mAnnouncement.Id != 0)
            {

                return View("AddAnnouncementAd", Announce);
            }
            else
            {
                return RedirectToAction("AnnouncementList", "AnnouncementAd");

            }
        }

        public ActionResult AnnouncementDelete(int Id)
        {
            List<MAnnouncement> mAnnouncements = new List<MAnnouncement>();

            mAnnouncements = adminBAL.AnnouncementDelete(Id);
            return RedirectToAction("AnnouncementList", "AnnouncementAd");
        }
    }
}