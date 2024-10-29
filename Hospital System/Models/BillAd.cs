using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class BillAd
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Problem { get; set; }
        public string BillingDate { get; set; }
        public decimal DoctorFee { get; set; } = 500;
        public int TreatmentDuration { get; set; }
        public decimal TreatmentCharges { get; set; }
        public decimal MedicineCharges { get; set; }
        public decimal RoomFee { get; set; }
        public string Others { get; set; }
        public decimal OthersCost { get; set; }
        public decimal TotalBill { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal InsuranceClaimed { get; set; }
        public decimal PaidBill { get; set; }
        public string Status { get; set; }
        public string MethodOfPayment { get; set; }
       
    }
}