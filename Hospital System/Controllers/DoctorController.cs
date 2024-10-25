using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hospital_System.Models;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;
using Hospital_System.Viewmodel;


namespace Hospital_System4r.Controllers
{
    public class DoctorController : Controller
    {
        MenuBAL menuBAL = new MenuBAL();
        DoctorBAL doctorBAL = new DoctorBAL();
        // GET: Doctor


      

        public ActionResult DoctorList(string searchvalue)
        {

            var doctor = doctorBAL.GetDoctors(searchvalue);

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                Doctors = doctor
            };


            return View(model);

        }









    }

}