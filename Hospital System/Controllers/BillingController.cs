using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class BillingController : Controller
    {
        InPatientBAL inpatientBal = new InPatientBAL();

        BillingBAL billingBAL= new BillingBAL();
        // GET: Billing
       

        public ActionResult InvoiceIP()
        {

            var model = billingBAL.GetBillings();
            return View(model);

        }
           
        public ActionResult BillingId (int PatientId)
        {
            var model = billingBAL.Billing1(PatientId);
            if(model== null)
            {
                return RedirectToAction("InvoiceIP");
            }
            return View(model);
        }

        public ActionResult AddBill(Billing Billing)
        {
            var ids = 0;
            var model = new Billing
            {

                DoctorFee = 500 // Default value

            };


            List<Billing> billAds = new List<Billing>();


            if (Billing.PatientId != 0)
            {
                billAds = billingBAL.AddBill(Billing);
            }
            if (billAds.Count == 0)
            {
                BillingDAL billDAL = new BillingDAL();
                if (Billing.PatientId == 0)
                {
                    ids = billDAL.BillId();
                }
                Billing.PatientId = ids + 1;

                return View(Billing);
            }
            else
            {
                return RedirectToAction("InvoiceIP", Billing);
            }


        }


        //Bill Edit

        public ActionResult BillE(int PatientId)
        {
            if (PatientId <= 0)
                return HttpNotFound();

            Billing billAd = new Billing();
            billAd = billingBAL.BillE(PatientId);
            if (billAd.PatientId != 0)
            {

                return View("AddBill", billAd);
            }
            else
            {
                return RedirectToAction("InvoiceIP", "Billing");

            }
        }


    }
}