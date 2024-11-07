using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;
using Hospital_System.Dash;

namespace Hospital_System.Controllers
{
    public class PatientAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: PatientAd

        public ActionResult PatientList(string patient)
        {
            MPatient mPatient1 = new MPatient();
            List<MPatient> mPatient = new List<MPatient>();
            mPatient = adminBAL.PatientList(patient);

            var mpatient = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                mPatients = mPatient
            };

               return View(mpatient);

        }



        //[HttpGet]
        //public ActionResult AddPatientAd()
        //    { return View(); }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddPatientAd(MPatient mPatient)
        //{
        //    var ids = 0;

        //    List<MPatient> mPatients = new List<MPatient>();


        //    if (mPatient.Id != 0)
        //    {
        //        mPatients = adminBAL.AddPatientAd(mPatient);
        //    }
        //    else if (mPatients.Count == 0)
        //    {
        //        adminDAL = new AdminDAL();
        //        if (mPatient.Id == 0)
        //        {
        //            ids = adminDAL.PatientId();
        //        }
        //        mPatient.Id = ids + 1;

        //        var mpatient = new DashboardDetails
        //        {
        //            Adminmenus = adminBAL.GetAdminmenus(),
        //            mPatient = mPatient
        //        };



        //        return View(mpatient);
        //    }
           
            
        //        return RedirectToAction("PatientList", mPatients);
            


        //}

        //public ActionResult PatientEdit(int Id)
        //{
        //    if (Id <= 0)
        //        return HttpNotFound();

        //    MPatient mPatient = new MPatient();
        //    mPatient = adminBAL.PatientEdit(Id);

        //    var mpatient = new DashboardDetails
        //    {
        //        Adminmenus = adminBAL.GetAdminmenus(),
        //        mPatient = mPatient
        //    };


        //    if (mPatient.Id != 0)
        //    {

        //        return View("AddPatientAd", mpatient);
        //    }
        //    else
        //    {
        //        return RedirectToAction("PatientList", "PatientAd");

        //    }
        //}
        //public ActionResult PatientDelete(int Id)
        //{
        //    List<MPatient> mPatients = new List<MPatient>();

        //    mPatients = adminBAL.PatientDelete(Id);
        //    return RedirectToAction("PatientList", "PatientAd");
        //}

    }
}