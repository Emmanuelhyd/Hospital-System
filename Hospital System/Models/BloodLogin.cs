using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class BloodLogin
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }

        public string Address { get; set; }


    }
}