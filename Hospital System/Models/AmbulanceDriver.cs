using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Models
{
    public class AmbulanceDriver
    {
        public int Id { get; set; }
        [Required]
        public string DriverName { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "CNIC")]
        public string CNIC { get; set; }
    }
}