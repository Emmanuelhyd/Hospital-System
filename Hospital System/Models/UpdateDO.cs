using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class UpdateDO
    {
        public int PatientId { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string PhoneNo { get; set; }
        public string EmergencyContact { get; set; }
        public string Address { get; set; }
        public string ConfirmPassword { get; set; }
        public int Type { get; set; }

    }
}