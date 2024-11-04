using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_System.Models
{
    public class Patients
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, ErrorMessage = "User Name cannot be longer than 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email must be a valid Gmail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Blood Group is required")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public string Age { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits.")]
        public string PhoneNo { get; set; }

        //[Required(ErrorMessage = "Emergency Contact is required")]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Emergency Contact must be 10 digits.")]
        public string EmergencyContact { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        


        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string UserNameOrEmail { get; set; }

        public int Type { get; set; }

        public IEnumerable<SelectListItem> BloodGroups { get; set; }
        public IEnumerable<SelectListItem> GetGenders { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}

