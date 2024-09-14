using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Hospital_System.Models
{
    public class Patients
    {


        //[Required(ErrorMessage = "Patient ID is required")]
        //public string PatientId { get; set; }

        //[Required(ErrorMessage = "LastName is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required")]

        public string Password { get; set; }

        //[Required(ErrorMessage = "Blood Group is required")]
        public string BloodGroup { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        //[Required(ErrorMessage = "Phone Number is required")]
        public string Age { get; set; }
        public string PhoneNo { get; set; }

        //[Required(ErrorMessage = "Emergency Contact is required")]

        public string EmergencyContact { get; set; }

        //[Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }



        //[Required(ErrorMessage = "Confirm Password is required")]

        //public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "First Name is required")]
        //public string FirstName { get; set; }
        //[Required(ErrorMessage = "Age is required")]


        public IEnumerable<SelectListItem> BloodGroups { get; set; }
        public IEnumerable<SelectListItem> GetGenders { get; set; }

    }




}
