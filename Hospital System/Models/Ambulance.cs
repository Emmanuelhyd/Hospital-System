using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Models
{
    public class Ambulance
    {
        internal List<Ambulance> Ambulances;
        internal int AmbulanceCount;

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int AmbulanceId { get; set; }

        
        public string AmbulanceStatus { get; set; }

        public string  AmbulanceDriver { get; set; }

        public int AmbulanceDriverId { get; set; }

        
    }

    public class AmbulanceViewModel
    {
        public List<Ambulance> Ambulances { get; set; }
        public int AmbulanceCount { get; set; }
    }


}
