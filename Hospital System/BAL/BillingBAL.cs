using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class BillingBAL
    {

        BillingDAL billingdal = new BillingDAL();

        public List<Billing> GetBillings()
        {

            return billingdal.GetBillings();
        }

        public Billing Billing1(int PatientId)
        {
            return billingdal.Billing1(PatientId);

        }

        public List<Billing> AddBill(Billing Billing)
        {
            List<Billing> billAds = new List<Billing>();
            billAds = billingdal.AddBill(Billing);
            return billAds;
        }


        //Bill edit
        public Billing BillE(int PatientId)
        {
            Billing billAds = billingdal.BillE(PatientId);

            return billAds;
        }
    }
}