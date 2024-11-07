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
using Hospital_System.Viewmodel;

namespace Hospital_System.Controllers
{
    public class AppointmentController : Controller
    {

        MenuBAL menuBAL = new MenuBAL();
        DoctorDAL doctorDAL;
        DoctorBAL doctorBAL = new DoctorBAL();
        // GET: Appointment
    
           
    
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

        public ActionResult BookList()
        {
            MAppointmentAd mAppointmentAd1 = new MAppointmentAd();
            List<MAppointmentAd> mAppointmentAd= new List<MAppointmentAd>();

            mAppointmentAd = doctorBAL.BookList();

            var model = new Allview()
            {
                Menus = menuBAL.GetMenus(),
                MAppointmentAds = mAppointmentAd,

            };
            return View(model);
        }
        private decimal LoggedInPatientId()
        {
            if (Session["PatientId"] != null && decimal.TryParse(Session["PatientId"].ToString(), out decimal patientId))
            {
                return patientId;
            }

            return 0;
        }
        public ActionResult AddBook(MAppointmentAd mAppointmentAd)
        {
           

            var ids = 0;
            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();

            if(mAppointmentAd == null)
            {
                mAppointmentAd = new MAppointmentAd();
            }


            if (mAppointmentAd.Id != 0)
            {
                mAppointmentAds = doctorBAL.AddBook(mAppointmentAd);
            }



            SessionDAL session = new SessionDAL();

            var patientId = Session["PatientId"] != null ? (int)Session["PatientId"] : 0;
            var patient = session.GetPaientDetails(patientId);

            if (mAppointmentAds.Count == 0)
            {
                doctorDAL = new DoctorDAL();
                if (mAppointmentAd.Id == 0)
                {
                    ids = doctorDAL.BookId();
                }
                mAppointmentAd.Id = ids + 1;

                mAppointmentAd.PatientName = patient.UserName;  
                mAppointmentAd.Gender = patient.Gender;   
                mAppointmentAd.PhoneNumber = patient.PhoneNo; 
                mAppointmentAd.Address= patient.Address;
                mAppointmentAd.Date = DateTime.Now.ToString("yyyy-MM-dd");
                mAppointmentAd.Time = DateTime.Now.ToString("HH:mm");

                



                var model = new Allview
                {
                   
                    Menus = menuBAL.GetMenus(),
                    GetTypes = new SelectList(GetPatientTypes(), "Value", "Text"),
                    Problems = new SelectList(Getproblems(), "Value", "Text"),
                    mAppointmentAd = mAppointmentAd

                };

               
                return View(model);
            }
            
                return RedirectToAction("BookList", mAppointmentAds);
            
        }

    }
}