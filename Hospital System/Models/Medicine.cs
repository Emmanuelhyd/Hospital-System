using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Models
{
    public class Medicine
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        //public int MedicineId { get; set; }
        
        public string MedicineName { get; set; }
        
        public string Description { get; set; }
        
        //public string Quantity { get; set; }
       
        //public int Price { get; set; }

        public string DoctorName { get; set; }
        public string Problem { get; set; }
      
        public string Morning { get; set; }
        public string Afternoon { get; set; }
        public string Night { get; set; }


    }
}