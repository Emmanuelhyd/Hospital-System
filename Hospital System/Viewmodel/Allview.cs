using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Viewmodel
{
    public class Allview
    {

        public int DepartmentCount { get; set; }
        public int DoctorCount { get; set; }
        public int PatientCount { get; set; }
        public int AmbulanceCount { get; set; }
        public int DriverCount { get; set; }
        public int MedicineCount { get; set; }
        public int ActiveAppointmentsCount { get; set; }
        public int PendingAppointmentsCount { get; set; }

    }
}