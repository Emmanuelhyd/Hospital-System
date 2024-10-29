using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public int PatientId { get; set; }

        public DateTime DateOfService { get; set; }

        public string ItemizedCharges { get; set; }
        public decimal DailyroomCharges { get; set; }
        public decimal TreatmentCharges { get; set; }
        public decimal MedicineCharges { get; set; }
        public decimal GST { get; set; }
        public decimal TotalAmountDue { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeDate { get; set; }
        public int TreatmentDuration { get; set; }

      
     
    }
}