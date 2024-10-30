using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hospital_System.Models
{
    public class Feedbk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Feedback { get; set; }
        public string Doctor { get; set; }
        public string Staff { get; set; }
        public string Cleaning { get; set; }

        public string Review { get; set; }
    }


    
}