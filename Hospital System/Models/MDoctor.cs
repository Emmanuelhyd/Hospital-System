using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MDoctor
    {


        
        public int DoctorId { get; set; }

        public string FullName { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

         public string Designation { get; set; }

         public string PhoneNo { get; set; }
        public string ContactNo { get; set; }


        public string Education { get; set; }

         public string Gender { get; set; }

         public string Status { get; set; }

    }
}