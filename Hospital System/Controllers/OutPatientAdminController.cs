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
    public class OutPatientAdminController : Controller
    {
        OutPatientAdDAL outPatientDAL;

        OutPatientAdBAL outPatientBAL=new OutPatientAdBAL();

        // GET: OutPatientAdmin
        public ActionResult OutPatientList()
        {
            MInPatient mInPatients = new MInPatient();
            List<MInPatient> mInPatient = new List<MInPatient>();

            mInPatient = outPatientBAL.OutPatientList();
            return View(mInPatient);
        }

        public ActionResult AddOutPatient(MInPatient mInPatient)
        {
            var ids = 0;

            List<MInPatient> mInPatients = new List<MInPatient>();


            if (mInPatient.Id != 0)
            {
                mInPatients = outPatientBAL.AddOutPatient(mInPatient);
            }
            if (mInPatients.Count == 0)
            {
                outPatientDAL = new OutPatientAdDAL();
                if (mInPatient.Id == 0)
                {
                    ids = outPatientDAL.OutpatientId();
                }
                mInPatient.Id = ids + 1;

                return View(mInPatient);
            }
            else
            {
                return RedirectToAction("OutPatientList", mInPatients);
            }


        }

        //Inpatient Edit

        public ActionResult OutPatientEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MInPatient mInPatient = new MInPatient();
            mInPatient = outPatientBAL.OutPatientEdit(Id);
            if (mInPatient.Id != 0)
            {

                return View("AddOutPatient", mInPatient);
            }
            else
            {
                return RedirectToAction("OutPatientList", "OutPatientAdmin");

            }
        }

        //Inpatient Delete

        public ActionResult OutPatientDelete(int Id)
        {
            List<MInPatient> mInPatients = new List<MInPatient>();

            mInPatients = outPatientBAL.OutPatientDelete(Id);
            return RedirectToAction("OutPatientList", "OutPatientAdmin");
        }

    }
}