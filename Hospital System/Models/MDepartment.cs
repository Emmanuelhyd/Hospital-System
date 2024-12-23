﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MDepartment
    {

        public int Id { get; set; }

        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public string Education { get; set; }

        public string Description { get; set; }
        public string Gender { get; set; }

        public string Status {  get; set; }
    }
}