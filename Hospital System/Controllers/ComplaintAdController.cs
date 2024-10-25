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

namespace Hospital_System.Controllers
{
    public class ComplaintAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: ComplaintAd
        public ActionResult ComplaintAdList()
        {
            MComplaintAd mComplaintAds = new MComplaintAd();
            List<MComplaintAd> mComplaintAd = new List<MComplaintAd>();

            mComplaintAd = adminBAL.ComplaintAdList();

            var complain = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mComplaintAds = mComplaintAd

            };

               return View(complain);
        }

        //add Complaint
        public ActionResult AddComplaintAd(MComplaintAd mComplaintAd)
        {

            var ids = 0;
            List<MComplaintAd> mComplaintAds = new List<MComplaintAd>();
            if (mComplaintAd.Id != 0)
            {
                mComplaintAds = adminBAL.AddComplaintAd(mComplaintAd);
            }
            if (mComplaintAds.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mComplaintAd.Id == 0)
                {
                    ids = adminDAL.ComplaintId();
                }
                mComplaintAd.Id = ids + 1;

                var complain = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    mComplaintAd = mComplaintAd

                };


                return View(complain);
            }
            else
            {
                return RedirectToAction("ComplaintAdList", mComplaintAds);
            }

        }

        //edit complaint

        public ActionResult ComplaintEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MComplaintAd mComplaintAd = new MComplaintAd();
            mComplaintAd = adminBAL.ComplaintEdit(Id);


            var complain = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mComplaintAd = mComplaintAd

            };



            if (mComplaintAd.Id != 0)
            {

                return View("AddComplaintAd", complain);
            }
            else
            {
                return RedirectToAction("ComplaintAdList", "ComplaintAd");

            }
        }

        public ActionResult ComplaintDelete(int Id)
        {
            List<MComplaintAd> mComplaintAds = new List<MComplaintAd>();

            mComplaintAds = adminBAL.ComplaintDelete(Id);
            return RedirectToAction("ComplaintAdList", "ComplaintAd");
        }
    }
}