using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MAppointmentAd
    {
       
        public int Id { get; set; }
        public string PatientType { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Problem { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }


    }
}