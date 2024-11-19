using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class OutpatientController : Controller
    {
        OPBAL opBal = new OPBAL();
        // GET: Outpatient
        public ActionResult OutP()
        {
            var model=opBal.GetPatients();
            return View(model); 
        }


        public ActionResult OPID( int Id)
        {
           var model = opBal.OPID (Id);
            if(model == null)
            {
                return RedirectToAction("OutP", "Outpatient");
            }
            return View(model);
        }
        
        public ActionResult PatientsList()
        {
            var model = opBal.GetHospPatients();
            return View(model);
        }
        //Edit
        public ActionResult PatientEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            HospPatient Hosp = new HospPatient();
            Hosp = opBal.PatientEdit(Id);
            if (Hosp.Id != 0)
            {

                return View("AddPatient", Hosp);
            }
            else
            {
                return RedirectToAction("PatientsList", "Outpatient");

            }
        }


        //Add
        public ActionResult AddPatient (HospPatient hospPatient)
        {

            var ids = 0;

            List<HospPatient> hosp = new List<HospPatient>();


            if (hospPatient.Id != 0)
            {
                hosp = opBal.AddPatients(hospPatient);
            }
            if (hosp.Count == 0)
            {
                OPDAL opdal = new OPDAL();
                if (hospPatient.Id == 0)
                {
                    ids = opdal.CommonId();
                }
                hospPatient.Id = ids + 1;


                if (hospPatient.TreatmentDuration == 0)
                {
                    
                    hospPatient.PatientType = "Out Patient";
                }


              
                return View(hospPatient);
            }
            else
            {
                return RedirectToAction("PatientsList", "Outpatient");
            }
        }


    }
}