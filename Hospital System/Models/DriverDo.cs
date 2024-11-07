using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class DriverDo
    {
        public int Id { get; set; }

        public string DriverName { get; set; }
        public int DriverId { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
    }
}