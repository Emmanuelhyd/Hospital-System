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


namespace Hospital_System4r.Controllers
{
    public class DoctorController : Controller
    {
        
        DoctorBAL doctorBAL = new DoctorBAL();
        // GET: Doctor


      

        public ActionResult DoctorList(string searchvalue)
        {

            var model = doctorBAL.GetDoctors(searchvalue);

            return View(model);

        }









    }

}