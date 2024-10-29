using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class NurseDo
    {
          public int NurseId { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DateOfJoining { get; set; }
        public string Specialization { get; set; }
        public string ShiftType { get; set; }
        public string Education { get; set; }
        public string EmployeeStatus { get; set; }
    }
}