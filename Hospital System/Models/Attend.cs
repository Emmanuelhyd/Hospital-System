﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class Attend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Contact { get; set; }

        public string Shift { get; set; }
        public string Time { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public string Status { get; set; }



    }
}