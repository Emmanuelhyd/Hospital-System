using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPages.Models
{
    public class MDoctor
    {


        
        public int Id { get; set; }

        public string Name { get; set; }
        public string Department { get; set; }

         public string Designation { get; set; }

         public long PhoneNumber { get; set; }

         public string Education { get; set; }

         public string Gender { get; set; }

         public string Status { get; set; }

    }
}