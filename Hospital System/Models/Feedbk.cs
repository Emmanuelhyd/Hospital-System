using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hospital_System.Models
{
    public class Feedbk
    {
        public int FeedBackId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Age must be a positive number.")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please rate our waiting room.")]
        [Range(1, 5, ErrorMessage = "Waiting room rating must be between 1 and 5.")]
        public int Waitingroom { get; set; }

        [Required(ErrorMessage = "Please rate our staff.")]
        [Range(1, 5, ErrorMessage = "Staff rating must be between 1 and 5.")]
        public int Staff { get; set; }

        [Required(ErrorMessage = "Please rate your nurse.")]
        [Range(1, 5, ErrorMessage = "Nurse rating must be between 1 and 5.")]
        public int Nurse { get; set; }

        [Required(ErrorMessage = "Please rate your doctor.")]
        [Range(1, 5, ErrorMessage = "Doctor rating must be between 1 and 5.")]
        public int Doctor { get; set; }

        [StringLength(1000, ErrorMessage = "Overall experience cannot exceed 1000 characters.")]
        public string OverallExperience { get; set; }
    }


    
}