using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MShedule
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string status { get; set; }

    }
}