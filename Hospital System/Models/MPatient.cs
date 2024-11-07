using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MPatient
    {

        public int Id { get; set; }
        
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}