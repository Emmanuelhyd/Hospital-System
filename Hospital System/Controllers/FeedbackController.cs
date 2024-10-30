using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class FeedbackController : Controller
    {

        FeedDAL feedDAL;
        FeedBAL feedBAL = new FeedBAL();
        // GET: Feedback


        //feedback list

        public ActionResult FeedList()
        {
            Feedbk feedbk = new Feedbk();
            List<Feedbk> feedbks = new List<Feedbk>();

            feedbks = feedBAL.FeedList();
            return View(feedbks);
        }

        public ActionResult Feed(Feedbk feedbk)
        {

            var ids = 0;

            List<Feedbk> feedbks = new List<Feedbk>();


            if (feedbk.Id != 0)
            {
                feedbks = feedBAL.Feed(feedbk);
            }
            if (feedbks.Count == 0)
            {
                feedDAL = new FeedDAL();
                if (feedbk.Id == 0)
                {
                    ids = feedDAL.FeedId();
                }
                feedbk.Id = ids + 1;

                return View(feedbk);
            }
            else
            {
                return RedirectToAction("FeedList", feedbks);
            }

        }
    }
}