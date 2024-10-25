using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Models
{
    public class MAppointmentAd
    {
       
        public int Id { get; set; }
        public string PatientType { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }

        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Problem { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
       
        public string AdmissionDate { get;set; }

        public string DischargeDate { get; set; }

        public string Typename { get; set; }

        public int TreatmentDuration { get; set; }

        public string Status { get; set; }
        public string Dailycharge { get; set; }

        public string Totalcharge { get; set; }

        public IEnumerable<SelectListItem> PatientTypes { get; set; }

        public IEnumerable<SelectListItem> Getproblems { get; set; }

    }
}