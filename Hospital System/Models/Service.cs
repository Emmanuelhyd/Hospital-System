using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class Service
    {

        public int ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }  

        public string Modifiers { get; set; }


    }
}