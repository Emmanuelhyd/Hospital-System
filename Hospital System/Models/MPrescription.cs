using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MPrescription
    {
        public int PatientId { get; set; }
        public string PatientName {  get; set; }
        public string DoctorName { get; set; }
        public string Problem { get; set; }
        public string Medicine { get; set; }
        public string Morning { get; set; }
        public string Afternoon { get; set; }
        public string Evening  { get; set; }

    }
}