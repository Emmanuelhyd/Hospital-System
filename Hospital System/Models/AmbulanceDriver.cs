using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class AmbulanceDriver
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "CNIC")]
        public int Cnic { get; set; }
    }
}