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



    }
}