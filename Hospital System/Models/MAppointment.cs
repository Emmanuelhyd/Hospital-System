using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MAppointment
    {
        public string DoctorName {  get; set; }
        public string Speciality { get; set; }
        public string Education { get; set; }
        public string Timings { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }

        public string PatientName {  get; set; }
        public string PatientType { get; set; }
        public string Problem { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }



    }
}