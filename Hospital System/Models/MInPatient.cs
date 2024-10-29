using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MInPatient
    {

        public int Id { get; set; }
        public string PatientName { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeDate { get; set; }
        public string PatientType { get; set; }
        public int TreatmentDuration { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string Problem { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }



        //public int PatientId { get; set; }
        //public string PatientName { get; set; }
        //public string AdmissionDate { get; set; }
        //public string Dischargedate {  get; set; }
        //public string PatientType { get; set; }
        //public int TreatmentDuration { get; set; }
        //public string AppointmentDate { get; set; }
        //public string Status { get; set; }

        //public string Problem { get; set; }
        //public string Description { get; set; }
        //public string Gender { get; set; }
        //public string Address { get; set; }
        //public string PhoneNumber { get; set; }
    }
}