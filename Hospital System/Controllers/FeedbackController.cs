using Hospital_System.BAL;
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


        FeedBAL feedBAL = new FeedBAL();
        // GET: Feedback

        [HttpGet]
        public ActionResult Feed()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feed(Feedbk feedbk)
        {
            if (ModelState.IsValid)
            {
                string res = feedBAL.Feed(feedbk);
                if (res == "Feedback Sent")
                {
                    TempData["Message"] = "Sent successfully";
                    return View("Feed");
                }
            }
            TempData["Message"] = "Error Occured";
            return View(feedbk);
        }
    }
}