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
        MenuBAL menuBAL = new MenuBAL();

        PatientBAL patientBAL = new PatientBAL();
        // GET: Patient
        //Login
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
                Session["Email"] = patients.Email;
                Session["UsernameorEmail"] = patients.UserNameOrEmail;



                //string Otp = GenerateOTP();
                //Session["GenerateOTP"] = Otp;
                //patientBAL.SendOTPtoMail(patients.Email, Otp); 

                switch (patients.Type)
                {
                    case 1: // Assuming 1 is for Admin
                        return RedirectToAction("DashboardView", "Dashboard", new { id = patients.PatientId });
                    case 2: // Assuming 2 is for Doctor
                        return RedirectToAction("Index", "Doctor", new { id = patients.PatientId });
                    case 3: // Assuming 3 is for Patient
                        return RedirectToAction("Dashboard", "Patient", new { id = patients.PatientId });
                    case 4: // Assuming 4 is for Staff
                        return RedirectToAction("Index", "Staff", new { id = patients.PatientId });
                    case 5: // Assuming 5 is for Reception
                        return RedirectToAction("Reception", "Reception", new { id = patients.PatientId });
                    default:
                        return RedirectToAction("Error", "Home"); // Handle unexpected user types
                }

             

                //return RedirectToAction("Dashboard");
            }
            else
            {
                TempData["InValid"] = "Invalid UserName or Password";
                return View();
            }


        }

        //generate OTP
        // private string GenerateOTP()
        //{
        //    Random random = new Random();
        //    return random.Next(10000, 100000).ToString();
        //}

        //verifyOTP
        //[HttpGet]
        //public ActionResult VerifyOTP()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult VerifyOTP(string userEnteredOtp)
        //{
        //    string generate = Session["GenerateOTP"].ToString();

        //    if(generate==userEnteredOtp)
        //    {
        //        return RedirectToAction("Dashboard", "Patient");
        //    }
        //    TempData["Message"] = "OTP is Invalid ";

        //    return View();
        //}




        //Signup
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
            var patientId = Session["PatientId"] != null ? (int)Session["PatientId"] : 0;
            var menu = menuBAL.GetMenus();

            var model = new Allview

            {

                Patients = new Patients
                {
                    PatientId = patientId,
                },

                Menus = menu,
                BloodGroups = new SelectList(GetBloodGroups(), "Value", "Text"),
                GetGenders = new SelectList(GetGenders(), "Value", "Text")
            };
            ViewBag.PatientId = patientId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(Patients patients)
        {
            if(ModelState.IsValid)
            {
                patients.BloodGroups = new SelectList(GetBloodGroups(), "Value", "Text");
                patients.GetGenders = new SelectList(GetGenders(), "Value", "Text");
                return View(patients);
            }

              
             var patientId = Session["PatientId"] != null ? (int)Session["PatientId"] : 0;
             patients.PatientId = patientId;


             string res = patientBAL.Updateprofile(patients);
            var updated = res;

            if (res == "1")
            {
                TempData["Message"] = "Profile updated successfully!";

                return RedirectToAction("Dashboard");
            }

          
            

            TempData["Message"] = "Invalid UserName";

            ViewBag.PatientId = patientId;

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                BloodGroups = new SelectList(GetBloodGroups(), "Value", "Text"),
                GetGenders = new SelectList(GetGenders(), "Value", "Text")
            };
            
            
            return View(model);
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
                Menus = menuBAL.GetMenus(),
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
        //Ambulance List
        public ActionResult Ambulanceses()
        {
            var ambulance = patientBAL.GetAmbulances();

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                ambulances = ambulance

            };
            return View(model);
        }


        //driver List
        public ActionResult Drive()
        {
            var drive = patientBAL.GetAmbulanceDrivers();
            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                Drivers = drive
            };

            return View(model);
        }

        //driver Popup

        public ActionResult GetdriverId(int DriverId)
        {
            AmbulanceDriver ambulance = patientBAL.GetdriverId(DriverId);
            if (ambulance == null)
            {
                return HttpNotFound("ID not found");
            }

            var driver = new Allview
            {
                Menus = menuBAL.GetMenus(),
                Driver = ambulance
            };
            return PartialView("_GetDriverId", driver);
        }
        //DoctorsList
        public ActionResult Doc()
        {
            var doctor = patientBAL.GetDoctors();
           

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                Doctors = doctor
            };

            return View(model);

        }
        //Doctor popup
        public ActionResult Doctordetails(int DoctorId)
        {
            Doctor doctor = patientBAL.GetDoctorsId(DoctorId);

            if (doctor == null)
            {
                return HttpNotFound("ID not found");
            }

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                doctors = doctor
            };

            return PartialView("_DoctorDetails", model);

        }
        //Medicines Id Based
        public ActionResult Medicals()
        {
            decimal Id = LoggedInPatientId();
            if (Id == 0)
            {
                return RedirectToAction("Dashboard");
            }
            var medicines = patientBAL.GetMedicines(Id);

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                Medicines = medicines

            };


            return View(model);

        }

        //Change Password

        [HttpGet]
        public ActionResult Changepassword()
        {
            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
            };
            
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Changepassword(Patients patients)
        {
            if (Session["UsernameorEmail"] != null || patients != null ||!string.IsNullOrEmpty(patients.UserNameOrEmail))
            {

                var username = Session["UsernameorEmail"].ToString();

                if (username == patients.UserNameOrEmail)

                { string res = patientBAL.Changepassword(patients);

                    if (res == "1")
                    {
                        TempData["valid"] = "Updated";
                        return RedirectToAction("Login", "Patient");
                    }

                }
            }

            
           
            TempData["valid"] = "Invalid UserName";

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
              
                
            };
            
             return View(model);

        }
        //forgotPassword
        [HttpGet]
        public ActionResult Forgotpassword()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgotpassword(Patients patients)
        {
          if(ModelState.IsValid)
            {
                TempData["Popup"] = "Check the username";
                return View(patients);
            }
           

            string res = patientBAL.Forgotpassword(patients);


                if (res == "1")
                {
                    Session["valid"] = "Updated";
                    return RedirectToAction("Login", "Patient");
                }
            

                TempData["valid"] = "Invalid UserName";

            

            return View(patients);
        }

        //prescription
        public ActionResult PrecList()
        {

            if (Session["PatientId"] == null)
            {
                return RedirectToAction("Dashboard", "Patient");
            }

            int PatientId = Convert.ToInt32(Session["PatientId"]);
            var medicines = patientBAL.GetMedicines(PatientId);


            if (medicines == null || !medicines.Any())
            {
                return View(medicines);
            }


            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                Medicines = medicines
                
            };


            return View(model);

        }


        public ActionResult Menu()
        {
            var menu = menuBAL.GetMenus();
            return View(menu);
        }


    }
}
       


  



































   
    
