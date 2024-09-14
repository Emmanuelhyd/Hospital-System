using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Hospital_System.Viewmodel;

namespace Hospital_System.Controllers
{
    public class PatientController : Controller
    {

        PatientBAL patientBAL = new PatientBAL();
        // GET: Patient
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( Custom custom)

        {
            string res = patientBAL.Login(custom);

          if(res== "success")
            {
                return RedirectToAction("Patientpage");
            }
            else
            {
                return View();
            }
           
           
        }

           

        public ActionResult Patientpage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Updateprofile(Patients patients)
        {
            var model = new Patients
            {
                
                BloodGroups = new SelectList(GetBloodGroups(), "Value", "Text"),
                GetGenders = new SelectList(GetGenders(), "Value", "Text")
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Updateprofilee(Patients patients)
        {
            if (ModelState.IsValid)
            {
                string res = patientBAL.Updateprofilee(patients);

                ViewBag.Message = res;
                return View(patients);
            }
            else
            {
                ViewBag.Message = "Invalid Email";
            }

            return View(patients);

        }
            private IEnumerable<SelectListItem> GetBloodGroups()
            {
                return new List<SelectListItem>
                {

                    new SelectListItem { Value = "A+", Text = "A+" },
                    new SelectListItem { Value = "B+", Text = "B+" },
                    new SelectListItem { Value = "AB+", Text = "AB+" },
                    new SelectListItem { Value = "O+", Text = "O+" },
                    new SelectListItem { Value = "A-", Text = "A-" },
                    new SelectListItem { Value = "B-", Text = "B-" },
                    new SelectListItem { Value = "AB-", Text = "AB-" },
                    new SelectListItem { Value = "O-", Text = "O-" }

                };

            }



            private IEnumerable<SelectListItem> GetGenders()
            {
                return new List<SelectListItem>
                {
                     new SelectListItem { Value = "Male", Text = "Male" },
                     new SelectListItem { Value = "Female", Text = "Female" },
                     new SelectListItem { Value = "Other", Text = "Other" }
                 };
            }

        

       
       




       
       

        public ActionResult Index()
        {
            var model = new Allview
            {
                DepartmentCount = patientBAL.GetDepartmentCount(),
                DoctorCount = patientBAL.GetDoctorCount(),
                PatientCount = patientBAL.GetPatientCount(),
                AmbulanceCount = patientBAL.GetAmbulanceCount(),
                DriverCount = patientBAL.GetDriverCount(),
                MedicineCount = patientBAL.GetMedicineCount(),
                ActiveAppointmentsCount = patientBAL.GetActiveAppointmentsCount(),
                PendingAppointmentsCount = patientBAL.GetPendingAppointmentsCount()
            };

            return View(model);
        }


       




       
        public ActionResult Ambulanceses()
        {
            var ambulance = patientBAL.GetAmbulances();
            return View(ambulance);
        }

       
        public ActionResult Depart()
        {
            var department=patientBAL.GetDepartments();
            return View(department);
        }

        public ActionResult drive()
        {
            var drive = patientBAL.GetAmbulanceDrivers();
            
            return View(drive);
        }

        public ActionResult doc()
        {
            var patient = patientBAL.GetDoctors();
            return View(patient);
        }

        public ActionResult medicals()
        {
            var medical = patientBAL.GetMedicines();
            return View(medical);
        }
        [HttpGet]
        public ActionResult Complaint()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complaint(Complain complain)
        {
            string res = patientBAL.Complaint(complain);
            ViewBag.message = "Added";
            return View(complain);
            
        }

        public ActionResult AddComplaints(string searchvalue)

        {  
            var complain = patientBAL.GetComplains(searchvalue);
            return View(complain);
        }
        [HttpGet]
        public ActionResult Changepassword()
        {
            return View();
        }
        [HttpPost]
            public ActionResult Changepassword(Custom custom)
        {
            string res = patientBAL.Changepassword(custom);
            if (res != "updated")
            {
                return RedirectToAction("Login");

            }


            ViewBag.message = "Password does not match";
            return View();
        }

        public ActionResult EditComplains(Complain complain)
        {
            if (complain == null)
            {
                return HttpNotFound(); 
            }

         
            string res = patientBAL.EditComplain(complain);

            if (res == "success")
            {
                return View("EditComplains", complain); 
            }
            else
            {
                return RedirectToAction("AddComplains", "Doctor");
            }
        }


    }



}
































   
    
