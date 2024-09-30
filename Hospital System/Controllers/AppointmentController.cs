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
        [HttpGet]
        public ActionResult BookAppointment()
        {
            var model = new MAppointment
            {
                Getproblems=new SelectList(Getproblems(),"value","Text"),
                PatientTypes = new SelectList(GetPatientTypes(), "Value", "Text")
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookAppointment(MAppointment mAppointment)

        {
            
          if (!ModelState.IsValid)
          {
             mAppointment.PatientTypes = GetPatientTypes(); 
            
          }
            string res = doctorBAL.BookAppointment(mAppointment);


            if (res == "1")
            {
                TempData["Message"] = "Booked Successfully";
                return RedirectToAction("BookAppointment");
            }
            
                TempData["message"] = "An error occurred. Please try again.";
           

            mAppointment.PatientTypes = GetPatientTypes();
            mAppointment.Getproblems = Getproblems();
            return View(mAppointment);
        }


        private IEnumerable<SelectListItem> GetPatientTypes()
        {
            return new List<SelectListItem>
    {
        new SelectListItem { Value = "New", Text = "New Patient" },
        new SelectListItem { Value = "Returning", Text = "Returning Patient" },
        new SelectListItem { Value = "Emergency", Text = "Emergency Patient" }
    };
        }


        private IEnumerable<SelectListItem> Getproblems()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value="Fever",Text="Viral Fever"},
                new SelectListItem { Value = "Cold", Text = "Cold" },
                new SelectListItem { Value = "Typhoid", Text = "Fever" },
                new SelectListItem { Value = "Malaria", Text = "Headache" },
                new SelectListItem { Value = "Dengue", Text = "Other" }
            };
        }





        public ActionResult Dash()
        {
            return View();
        }
    }
}