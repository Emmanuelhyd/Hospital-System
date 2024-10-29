using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class HospPatient
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public string Problem {  get; set; }

        public string PatientType { get; set; }

        public string Description { get; set; }

        public  string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public  string Address { get; set; }

        public string City { get; set; }

        public string AdmissionDate {get; set; }

        public string Dischargedate { get; set; }   

        public string TypeName { get; set; }

        public int  TreatmentDuration { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }

        public decimal Dailycharge { get; set; }
       


    }
}