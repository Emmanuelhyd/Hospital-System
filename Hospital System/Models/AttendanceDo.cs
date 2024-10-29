using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class AttendanceDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Shift { get; set; }
        public string Department { get; set; }
        public string Attendance { get; set; }

    }
}