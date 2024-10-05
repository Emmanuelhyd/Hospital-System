using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MComplaintAd
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Complaint { get; set; }
        public string PhoneNumber { get; set; }
        public string Replay { get; set; }

    }
}