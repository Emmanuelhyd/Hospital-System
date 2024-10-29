using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class BillBAL
    {
        BillDAL billDAL=new BillDAL();

        public List<BillAd> BillList()
        {
            return billDAL.BillList();
        }

        //Add Bill 

        public List<BillAd> AddBill(BillAd billAd)
        {
            List<BillAd> billAds = new List<BillAd>();
            billAds = billDAL.AddBill(billAd);
            return billAds;
        }


        //Bill edit
        public BillAd BillEdit(int PatientId)
        {
            BillAd billAds = billDAL.BillEdit(PatientId);

            return billAds;
        }
        //Bill delete
        public List<BillAd> BillDelete(int PatientId)
        {
            List<BillAd> billAds = billDAL.BillDelete(PatientId);
            return billAds;
        }

        public BillAd Billing1(int PatientId)
        {
            return billDAL.Billing1(PatientId);

        }

        //public MInPatient GetMInPatient(int PatientId)
        //{
        //    return billDAL.GetMInPatient(PatientId);
        //}
    }
}