using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MAmbulance
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int AmbulanceId { get; set; }
        public string AmbulanceStatus { get; set; }

        public string AmbulanceDriver { get; set; }

        public int AmbulanceDriverId { get; set; }


        public List<Menu> GetMenus { get; set; }


        //public IEnumerable<SelectListItem> AmbulanceStatus { get; set; }
    }
}