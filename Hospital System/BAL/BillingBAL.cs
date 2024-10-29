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
    }
}