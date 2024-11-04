using Hospital_System.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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

        public IEnumerable<Menu> Menus { get; set; }

        public Patients Patients { get; set; }

        public MAppointmentAd mAppointmentAd { get; set; }

        public MDepartment mDepartment { get; set; }

        public MComplaint mComplaint { get; set; }

        public SelectList BloodGroups { get; set; }

        public SelectList GetGenders { get; set; }

        public Doctor doctors { get; set; }

        public AmbulanceDriver Driver { get; set; }

        public List<Doctor> Doctors { get; set; }
        public List<Ambulance> ambulances { get; set; }

        public List<MAppointmentAd> MAppointmentAds { get; set; }

        public List<Medicine> Medicines { get; set; }
        public  List<AmbulanceDriver> Drivers { get; set; }
        public List <MComplaint> mComplaints { get; set; } 

        public SelectList GetTypes { get; set; }
        public SelectList Problems { get; set; }

       public string UserNameorEmail { get; set; }



    }
}