using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;
namespace Hospital_System.Controllers
{
    public class BillAdminController : Controller
    {
        CommonBAL commonBAL=new CommonBAL();
        

        CommonDAL commonDAL;
        BillBAL billBAL=new BillBAL();
        BillDAL billDAL;
        // GET: BillAdmin
        public ActionResult BillList()
        {
            BillAd billAd = new BillAd();

            List<BillAd> billAds = new List<BillAd>();

            billAds = billBAL.BillList();
            return View(billAds);
        }

        //add Bill

        public ActionResult AddBill(BillAd billAd)
        {
            var ids = 0;
            var model = new BillAd
            {
                
                DoctorFee = 500 // Default value

            };

//            MInPatient mInPatient = commonBAL.AddCommonOP(mInPatient)

//            if (mInPatient == null)

//            {
//                return RedirectToAction("Reception");
//            }


            //using (var context = new ApplicationDbContext())
            //{
            //    var commonOps = context.CommonOps.ToList();
            //    ViewBag.TreatmentDurations = new SelectList(commonOps, "Id", "TreatmentDuration");
            //}

            List<BillAd> billAds = new List<BillAd>();


            if (billAd.PatientId != 0)
            {
                billAds = billBAL.AddBill(billAd);
            }
            if (billAds.Count == 0)
            {
                billDAL = new BillDAL();
                if (billAd.PatientId == 0)
                {
                    ids = billDAL.BillId();
                }
                billAd.PatientId = ids + 1;

                return View(billAd);
            }
            else
            {
                return RedirectToAction("BillList", billAds);
            }


        }


        //Bill Edit

        public ActionResult BillEdit(int PatientId)
        {
            if (PatientId <= 0)
                return HttpNotFound();

            BillAd billAd = new BillAd();
            billAd = billBAL.BillEdit(PatientId);
            if (billAd.PatientId != 0)
            {

                return View("AddBill", billAd);
            }
            else
            {
                return RedirectToAction("BillList", "BillAdmin");

            }
        }

        //Bill Delete

        public ActionResult BillDelete(int PatientId)
        {
            List<BillAd> billAds = new List<BillAd>();

            billAds = billBAL.BillDelete(PatientId);
            return RedirectToAction("BillList", "BillAdmin");
        }


        public ActionResult BillingId(int PatientId)
        {
            var model = billBAL.Billing1(PatientId);
            if (model == null)
            {
                return RedirectToAction("InvoiceIP");
            }
            return View(model);
        }


        //public ActionResult GetMInPatient(int PatientId)
        //{

        //    List<BillAd> billAds = new List<BillAd>();
        //    MInPatient mInPatient =billBAL.GetMInPatient(PatientId);

        //    var model = billBAL.AddBill(PatientId);
        //    if (PatientId == 0)
        //    {
        //        return View(model);
        //    }
        //    else
        //    {
        //        return RedirectToAction("BillList", billAds);
        //    }

        //}



    }
}