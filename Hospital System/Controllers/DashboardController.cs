using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Dash;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class DashboardController : Controller
    {
        AdminBAL adminBAL = new AdminBAL();
        // GET: Dashboard
        public ActionResult DashboardView()
        {

            Patients patients = new Patients();



            var model = new DashboardDetails
            {
              
                MAmbulanceCount = adminBAL.GetMAmbulanceCount(),
                MAnnouncementCount = adminBAL.GetMAnnouncementCount(),
                MAppointmentCount = adminBAL.GetMAppointmentCount(),
                MComplaintAdCount = adminBAL.GetMComplaintAdCount(),
                MDepartmentCount = adminBAL.GetMDepartmentCount(),
                MDoctorCount = adminBAL.GetMDoctorCount(),
                MDriverAdCount = adminBAL.GetMDriverAdCount(),
                MMedicineAdCount = adminBAL.GetMMedicineAdCount(),
                MPatientCount = adminBAL.GetMPatientCount(),
                MSheduleCount = adminBAL.GetMSheduleCount(),
                Adminmenus = adminBAL.GetAdminmenus(),
                //TodayDate = DateTime.Now // Set today's date


            };
            return View(model);
        }


        public ActionResult GetMenus()
        {
            var model = adminBAL.GetAdminmenus();
            return View(model);
        }
    }
}