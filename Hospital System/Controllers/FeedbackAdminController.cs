using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;

namespace Hospital_System.Controllers
{
    public class FeedbackAdminController : Controller
    {
        FeedbackAdDAL feedbackDAL;
        FeedbackAdBAL feedbackBAL= new FeedbackAdBAL();
        // GET: FeedbackAdmin
        public ActionResult FeedbackListAdmin()
        {
            FeedbackDo feedbackDo = new FeedbackDo();
            List<FeedbackDo> feedbackDos = new List<FeedbackDo>();

            feedbackDos = feedbackBAL.FeedbackListAdmin();
            return View(feedbackDos);
        }


        //add Feedback

        public ActionResult AddFeedbackAd(FeedbackDo feedbackDo)
        {
            var ids = 0;

            List<FeedbackDo> feedbackDos = new List<FeedbackDo>();


            if (feedbackDo.Id != 0)
            {
                feedbackDos = feedbackBAL.AddFeedbackAd(feedbackDo);
            }
            if (feedbackDos.Count == 0)
            {
                feedbackDAL = new FeedbackAdDAL();
                if (feedbackDo.Id == 0)
                {
                    ids = feedbackDAL.FeedbackId();
                }
                feedbackDo.Id = ids + 1;

                return View(feedbackDo);
            }
            else
            {
                return RedirectToAction("FeedbackListAdmin", feedbackDos);
            }

        }
        //Feedback Edit

        public ActionResult FeedbackEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            FeedbackDo feedbackDo = new FeedbackDo();
            feedbackDo = feedbackBAL.FeedbackEdit(Id);
            if (feedbackDo.Id != 0)
            {

                return View("AddFeedbackAd", feedbackDo);
            }
            else
            {
                return RedirectToAction("FeedbackListAdmin", "FeedbackAdmin");

            }
        }

        //Attenance Delete

        public ActionResult FeedbackDelete(int Id)
        {
            List<FeedbackDo> feedbackDos = new List<FeedbackDo>();

            feedbackDos = feedbackBAL.FeedbackDelete(Id);
            return RedirectToAction("FeedbackListAdmin", "FeedbackAdmin");
        }



    }

}