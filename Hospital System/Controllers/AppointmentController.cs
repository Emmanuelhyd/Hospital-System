using Hospital_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hospital_System.Models;
using Hospital_System.DAL;
using System.Reflection;

namespace Hospital_System.Controllers
{
    public class AppointmentController : Controller
    {

        DoctorBAL doctorBAL = new DoctorBAL();
        // GET: Appointment
        public ActionResult AppointmentList(string searchvalue)
        {
            
            var mAppointment = doctorBAL.GetAppointmentList(searchvalue);
            return View(mAppointment);

        }

        public ActionResult BookAppointment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BookAppointment(MAppointment mAppointment)
        {
            string res = doctorBAL.BookAppointment(mAppointment);
            if (res.Contains("1"))
            {
                return Redirect("BookAppointment");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Dash()
        {
            return View();
        }
    }
}