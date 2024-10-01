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
using System.Runtime.Remoting.Contexts;
using System.Drawing;
using System.Diagnostics;

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
        public ActionResult Login(Patients patients)

        {
            string res = patientBAL.Login(patients);

            if (res == "success")
            {
                Session["UserName"] = patients.UserName;
                Session["PatientId"] = patients.PatientId;

                return RedirectToAction("Dashboard");
            }
            else
            {
                TempData["InValid"] = "Invalid UserName or Password";
                return View();
            }


        }
        [HttpGet]
        public ActionResult Insertprofile()
        {
            return View(new Patients());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insertprofile(Patients patients)
        {
            if (!ModelState.IsValid)
            {
                string res = patientBAL.Insertprofile(patients);
                if (res == "1")
                {

                    TempData["result"] = "Registered";
                    return RedirectToAction("Login");
                }
            }

            TempData["result"] = "Enter All the details";


            return View(patients);
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
        public ActionResult UpdateProfile(Patients patients)
        {

            if (Session["UserName"].ToString() == patients.UserName)

            {
                string res = patientBAL.Updateprofile(patients);


                if (res == "1")
                {
                    TempData["Message"] = "Profile updated successfully!";

                    return RedirectToAction("Login");
                }
            }


            TempData["Message"] = "Invalid UserName";



            patients.BloodGroups = GetBloodGroups();
            patients.GetGenders = GetGenders();
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


        public ActionResult Dashboard()
        {
            var model = new Allview
            {
                DepartmentCount = patientBAL.GetDepartmentCount(),
                DoctorCount = patientBAL.GetDoctorCount(),
                PatientCount = patientBAL.GetPatientCount(),
                AmbulanceCount = patientBAL.GetAmbulanceCount(),
                DriverCount = patientBAL.GetDriverCount(),
                ActiveAppointmentsCount = patientBAL.GetActiveAppointmentsCount(),
                PendingAppointmentsCount = patientBAL.GetPendingAppointmentsCount()
            };

            decimal patientId = LoggedInPatientId();
            if (patientId != 0)
            {
                model.MedicineCount = patientBAL.GetMedicineCount(patientId);
            }
            else
            {
                model.MedicineCount = 0;
            }

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

        public ActionResult Ambulanceses()
        {
            var ambulance = patientBAL.GetAmbulances();
            return View(ambulance);
        }



        public ActionResult Drive()
        {
            var drive = patientBAL.GetAmbulanceDrivers();

            return View(drive);
        }



        public ActionResult GetdriverId(int DriverId)
        {
            AmbulanceDriver ambulance = patientBAL.GetdriverId(DriverId);
            if (ambulance == null)
            {
                return HttpNotFound("ID not found");
            }
            return PartialView("_GetDriverId", ambulance);
        }

        public ActionResult Doc()
        {
            var doctor = patientBAL.GetDoctors();

            return View(doctor);

        }
        public ActionResult Doctordetails(int DoctorId)
        {
            Doctor doctor = patientBAL.GetDoctorsId(DoctorId);

            if (doctor == null)
            {
                return HttpNotFound("ID not found");
            }

            return PartialView("_DoctorDetails", doctor);

        }

        public ActionResult Medicals()
        {
            decimal patientId = LoggedInPatientId();
            if (patientId == 0)
            {
                return RedirectToAction("Dashboard");
            }
            var medicines = patientBAL.GetMedicines(patientId);

            return View(medicines);

        }



        [HttpGet]
        public ActionResult Changepassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Changepassword(Patients patients)
        {
            if (Session["UserName"].ToString() == patients.UserName)

            {
                string res = patientBAL.Changepassword(patients);

                if (res == "1")
                {
                    TempData["valid"] = "Updated";
                    return RedirectToAction("Login", "Patient");
                }

            }


            TempData["valid"] = "Invalid UserName";


            return View(patients);

        }
        [HttpGet]
        public ActionResult Forgotpassword()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgotpassword(Patients patients)
        {
            if (Session["UserName"].ToString() == patients.UserName)

            {
                string res = patientBAL.Changepassword(patients);


                if (res == "1")
                {
                    Session["valid"] = "Updated";
                    return RedirectToAction("Login", "Patient");
                }
            }

          
               
                TempData["valid"] = "Invalid UserName";

            

            return View(patients);
        }


        public ActionResult PrecList()
        {

            if (Session["PatientId"] == null)
            {
                return RedirectToAction("Dashboard", "Patient");
            }

            int patientId = Convert.ToInt32(Session["PatientId"]);
            var medicines = patientBAL.GetMedicines(patientId);


            if (medicines == null || !medicines.Any())
            {
                return View(medicines);
            }


            return View(medicines);



        }
    }
}
       


  



































   
    
