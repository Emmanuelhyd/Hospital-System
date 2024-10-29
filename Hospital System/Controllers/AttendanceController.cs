using Hospital_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class AttendanceController : Controller
    {
        AttendBAL attendBAL = new AttendBAL();
        // GET: Atterndance
        public ActionResult AttendanceDetails()
        {
            var attendance = attendBAL.AttendanceDetails();
            return View(attendance);
        }
    }
}