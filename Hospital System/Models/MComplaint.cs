using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MComplaint
    {
       
            [Required(ErrorMessage = "This field is required.")]
            public int Id { get; set; }

            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Please fill your complaints.")]
            public string Complaint { get; set; }

            [Required(ErrorMessage = "This field is required.")]
            [Phone(ErrorMessage = "Invalid phone number.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "This field is required.")]
            public string Replay { get; set; }
        


    }
}