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
    public class CommonOPController : Controller
    {
        CommonDAL commonDAL;
        CommonBAL commonBAL=new CommonBAL();

        // GET: CommonOP
        public ActionResult CommonList()
        {
            MInPatient mInPatient = new MInPatient();

            List<MInPatient> mInPatients = new List<MInPatient>();


            mInPatients = commonBAL.CommonList();
            return View(mInPatients);
        }

        //Add Common OP List 

        public ActionResult AddCommonOP(MInPatient mInPatient)
        {

            var ids = 0;

            List<MInPatient> mInPatients = new List<MInPatient>();


            if (mInPatient.Id != 0)
            {
                mInPatients = commonBAL.AddCommonOP(mInPatient);
            }
            if (mInPatients.Count == 0)
            {
                commonDAL = new CommonDAL();
                if (mInPatient.Id == 0)
                {
                    ids = commonDAL.CommonId();
                }
                mInPatient.Id = ids + 1;


                if (mInPatient.TreatmentDuration == 0)
                {
                    // Ensure the PatientType is set to Out Patient
                    mInPatient.PatientType = "Out Patient";
                }


                //// Store data based on TreatmentDuration
                //if (mInPatient.TreatmentDuration == 0)
                //{
                //    // Outpatient case
                //    commonDAL.OutPatientList(mInPatient);
                //}
                //else
                //{
                //    // Inpatient case
                //    commonDAL.InPatientListAd(mInPatient);
                //}
                return View(mInPatient);
            }
            else
            {
                return RedirectToAction("CommonList", mInPatients);
            }
        }

        //Discharge Edit

        public ActionResult CommonEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MInPatient mInPatient = new MInPatient();
            mInPatient = commonBAL.CommonEdit(Id);
            if (mInPatient.Id != 0)
            {

                return View("AddCommonOP", mInPatient);
            }
            else
            {
                return RedirectToAction("CommonList", "CommonOP");

            }
        }

        //discharge delete
        public ActionResult CommonDelete(int Id)
        {
            List<MInPatient> mInPatients = new List<MInPatient>();

            mInPatients = commonBAL.CommonDelete(Id);
            return RedirectToAction("CommonList", "CommonOP");
        }


    }
}