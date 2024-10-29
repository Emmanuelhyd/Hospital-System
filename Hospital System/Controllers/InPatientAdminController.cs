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
    public class InPatientAdminController : Controller
    {
        InPatientAdDAL inPatientDAL;
        InPatientAdBAL inPatientBAL=new InPatientAdBAL();


        // GET: InPatientAdmin
        public ActionResult InPatientListAd()
        {
            MInPatient mInPatients = new MInPatient();
            List<MInPatient> mInPatient = new List<MInPatient>();

            mInPatient = inPatientBAL.InPatientListAd();
            return View(mInPatient);

        }

        //add Inpatient details

        public ActionResult AddInpatient(MInPatient mInPatient)
        {
            var ids = 0;

            List<MInPatient> mInPatients = new List<MInPatient>();


            if (mInPatient.Id != 0)
            {
                mInPatients = inPatientBAL.AddInpatient(mInPatient);
            }
            if (mInPatients.Count == 0)
            {
                inPatientDAL = new InPatientAdDAL();
                if (mInPatient.Id == 0)
                {
                    ids = inPatientDAL.InpatientId();
                }
                mInPatient.Id = ids + 1;

                return View(mInPatient);
            }
            else
            {
                return RedirectToAction("InPatientListAd", mInPatients);
            }


        }

        //Inpatient Edit

        public ActionResult InPatientEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MInPatient mInPatient = new MInPatient();
            mInPatient = inPatientBAL.InPatientEdit(Id);
            if (mInPatient.Id != 0)
            {

                return View("AddInpatient", mInPatient);
            }
            else
            {
                return RedirectToAction("InPatientListAd", "InPatientAdmin");

            }
        }

        //Inpatient Delete

        public ActionResult InPatientDelete(int Id)
        {
            List<MInPatient> mInPatients = new List<MInPatient>();

            mInPatients = inPatientBAL.InPatientDelete(Id);
            return RedirectToAction("InPatientListAd", "InPatientAdmin");
        }


        //public ActionResult GetMInPatient(int PatientId)
        //{ 
        //   var model = inPatientBAL.GetMInPatient(PatientId);
        //    if(pa)
        //}
    }
}