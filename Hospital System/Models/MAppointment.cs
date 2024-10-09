using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Models
{
    public class MAppointment
    {
       
        public int Id { get; set; }


            [Required(ErrorMessage = "Doctor Name is required.")]
            [StringLength(100, ErrorMessage = "Doctor Name cannot be longer than 100 characters.")]
            public string DoctorName { get; set; }

            [Required(ErrorMessage = "Speciality is required.")]
            [StringLength(50, ErrorMessage = "Speciality cannot be longer than 50 characters.")]
            public string Speciality { get; set; }

            [Required(ErrorMessage = "Education is required.")]
            [StringLength(150, ErrorMessage = "Education cannot be longer than 150 characters.")]
            public string Education { get; set; }

            [Required(ErrorMessage = "Timings are required.")]
            public string Timings { get; set; }

            [Required(ErrorMessage = "Gender is required.")]
            public string Gender { get; set; }

            public string Action { get; set; }

            [Required(ErrorMessage = "Patient Name is required.")]
            [StringLength(100, ErrorMessage = "Patient Name cannot be longer than 100 characters.")]
            public string PatientName { get; set; }

            [Required(ErrorMessage = "Patient Type is required.")]
            [StringLength(50, ErrorMessage = "Patient Type cannot be longer than 50 characters.")]
            public string PatientType { get; set; }

            [Required(ErrorMessage = "Problem description is required.")]
            [StringLength(250, ErrorMessage = "Problem description cannot be longer than 250 characters.")]
            public string Problem { get; set; }

            [Required(ErrorMessage = "Phone Number is required")]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Address is required.")]
            [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Date is required.")]
            [DataType(DataType.Date)]
            public string Date { get; set; }

            [Required(ErrorMessage = "Time is required.")]
            [DataType(DataType.Time)]
            public string Time { get; set; } 


            public string Description { get; set; }

           



    }
    }



