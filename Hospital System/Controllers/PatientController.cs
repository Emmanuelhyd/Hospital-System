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
        public ActionResult Login( Patients patients)

        {
            string res = patientBAL.Login(patients);

          if(res== "success")
            {
                return RedirectToAction("Patientpage");
            }
            else
            {
                ViewBag.message = "Invalid UserName or Password";
                return View();
            }
           
           
        }

           

        public ActionResult Patientpage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Updateprofile()
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

        public ActionResult Updateprofile(Patients patients)
        {
            if (ModelState.IsValid)
            {
                string res = patientBAL.Updateprofile(patients);

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

        //public ActionResult AddComplaints(string searchvalue)

        //{  
        //    var complain = patientBAL.GetComplains(searchvalue);
        //    return View(complain);
        //}



        [HttpPost]
        public ActionResult EEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();


            Complain comp = new Complain();
            comp = patientBAL.EEdit(Id);
            if (comp.Id != 0)
            {

                return View("Complaint", comp);
            }
            else
            {
                return RedirectToAction("AddComplaint", "Patient");
            }
        }







        [HttpGet]
        public ActionResult Changepassword()
        {
            return View();
        }
        [HttpPost]
            public ActionResult Changepassword(Patients patients)
        {

           
            
            string res = patientBAL.Changepassword(patients);

            if (res=="updated")
            {
                Session["validate"] = "Updated";
                return RedirectToAction("Login");
                
            }
            else
            {
                Session["validate"] = "";
                ViewBag.message = "Invalid UserName";
            }
          
            return View();
        
        }

        //public ActionResult EditComplains(Complain complain)
        //{
        //    if (complain == null)
        //    {
        //        return HttpNotFound(); 
        //    }

         
        //    string res = patientBAL.EditComplain(complain);

        //    if (res == "success")
        //    {
        //        return View("EditComplains", complain); 
        //    }
        //    else
        //    {
        //        return RedirectToAction("AddComplains", "Patient");
        //    }
        //}


    }



}
































   
    
