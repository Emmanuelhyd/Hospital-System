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


namespace Hospital_System.Controllers
{
    public class DoctorController : Controller
    {
        
        DoctorBAL doctorBAL = new DoctorBAL();
        // GET: Doctor
        public ActionResult NewDoctor()
        {
            return PartialView("NewDoctor");
        }
        [HttpPost]
        public ActionResult NewDoctor(Doctors doctors)
        {
            string res = doctorBAL.NewDoctor(doctors);
            if (res.Contains("1"))
            {
                return Redirect("DoctorList");
            }
            else
            {

                return View();

            }
        }

        public ActionResult DoctorList(string Sagar)
        {
            Doctors doctors1 = new Doctors();
            List<Doctors> doctors = new List<Doctors>();

            doctors = doctorBAL.DoctorList(Sagar);
            return View(doctors);
        }

        //public ActionResult DEdit()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult DEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();


            Doctors doctors = new Doctors();
            doctors= doctorBAL.DEdit(Id);
            if (doctors.Id!=0)
            {

                return View("NewDoctor", doctors);
            }
            else
            {
                return RedirectToAction("DoctorList", "Doctor");
               

            }
        }

        //public ActionResult DDelete()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult DDelete(int Id)
        {
            List<Doctors> doctors = new List<Doctors>();

            doctors = doctorBAL.DDelete(Id);
            return RedirectToAction("DoctorList","Doctor");
        }



        //public ActionResult PrecList()
        //{
        //    //MPrescription mPrescription = new MPrescription();
        //    var mPrescription = doctorBAL.GetPrecList();
        //    return View(mPrescription);

        //}
    }

}