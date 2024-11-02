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
using Hospital_System.Dash;


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

            var medicine = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                MedicineAds = mMedicineAd
            };


            return View(medicine);
        }

        //add medicine
        public ActionResult AddMedicineAd(MMedicineAd mMedicineAd)
        {
            //if (ModelState.IsValid)
            //{
            //    // Map values to symbols
            //    mMedicineAd.Morning = mMedicineAd.Morning == "Yes" ? "✔" : "✖";
            //    mMedicineAd.Afternoon = mMedicineAd.Afternoon == "Yes" ? "✔" : "✖";
            //    mMedicineAd.Night = mMedicineAd.Night == "Yes" ? "✔" : "✖";
               
            //}
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

                    var medicine = new DashboardDetails
                    {
                        Adminmenus = adminBAL.GetAdminmenus(),
                        MMedicineAd = mMedicineAd
                    };



                    return View(medicine);
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

            var medicine = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                MMedicineAd = mMedicineAd
            };


            if (mMedicineAd.PatientId != 0)
            {

                return View("AddMedicineAd", medicine);
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