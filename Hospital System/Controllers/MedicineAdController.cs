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
    public class MedicineAdController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: MedicineAd
        public ActionResult MedicineAdList(string med)
        {
            MMedicineAd mMedicineAds = new MMedicineAd();
            List<MMedicineAd> mMedicineAd = new List<MMedicineAd>();

            mMedicineAd = adminBAL.MedicineAdList(med);
            return View(mMedicineAd);
        }

        //add medicine
        public ActionResult AddMedicineAd(MMedicineAd mMedicineAd)
        {
            var ids = 0;

            List<MMedicineAd> mMedicineAds = new List<MMedicineAd>();


            if (mMedicineAd.PatientId != 0)
            {
                mMedicineAds = adminBAL.AddMedicineAd(mMedicineAd);
            }
            if (mMedicineAds.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mMedicineAd.PatientId == 0)
                {
                    ids = adminDAL.MedicineId();
                }
                mMedicineAd.PatientId = ids + 1;

                return View(mMedicineAd);
            }
            else
            {
                return RedirectToAction("MedicineAdList", mMedicineAds);
            }

        }

        //edit Medicine

        public ActionResult MedicineEdit(int PatientId)
        {
            if (PatientId <= 0)
                return HttpNotFound();

            MMedicineAd mMedicineAd = new MMedicineAd();
            mMedicineAd = adminBAL.MedicineEdit(PatientId);
            if (mMedicineAd.PatientId != 0)
            {

                return View("AddMedicineAd", mMedicineAd);
            }
            else
            {
                return RedirectToAction("MedicineAdList", "MedicineAd");

            }
        }
        public ActionResult MedicineDelete(int PatientId)
        {
            List<MMedicineAd> mMedicineAds = new List<MMedicineAd>();

            mMedicineAds = adminBAL.MedicineDelete(PatientId);
            return RedirectToAction("MedicineAdList", "MedicineAd");
        }

    }
}