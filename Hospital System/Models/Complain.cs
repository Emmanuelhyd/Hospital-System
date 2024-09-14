using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class Complain
    {
        public int Id { get; set; }

        public string Complaint { get; set; }
        public string Reply { get; set; }
        public DateTime? ComplainDate { get; set; }



    }
}