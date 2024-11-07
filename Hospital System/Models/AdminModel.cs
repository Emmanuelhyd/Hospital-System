using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class AdminModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }
        public DateTime RejectedTime { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string ApprovalStatus { get; set; }
        [Required]
        public int ReferenceId { get; set; }
        public string Address { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }
        public string Status { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        public string Quantity { get; set; }
        public String Decease { get; set; }
        public int TotalDonors { get; set; }
        public string RelationWithDonor { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }
        public string Name { get; set; }

        public bool RememberMe { get; set; }
        public bool IsApproved { get; set; }
    }
}