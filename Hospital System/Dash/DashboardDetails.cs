using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Hospital_System.Dash
{
    public class DashboardDetails
    {
        public int MAmbulanceCount { get; set; }
        public int MAnnouncementCount { get; set; }
        public int MAppointmentCount { get; set; }
        public int MComplaintAdCount { get; set; }
        public int MDepartmentCount { get; set; }
        public int MDoctorCount { get; set; }
        public int MDriverAdCount { get; set; }
        public int MMedicineAdCount { get; set; }
        public int MPatientCount { get; set; }
        public int MSheduleCount { get; set; }

        public List<Adminmenu> Adminmenus { get; set; }

        public List<MAmbulance> mAmbulances { get; set; }

        public MAmbulance mAmbulance { get; set; }

        public List<MAnnouncement> mAnnouncements { get; set; }

        public List<MAppointmentAd> mAppointmentAds { get; set; }

        public MAnnouncement mAnnouncement { get; set; }

        public MAppointmentAd MAppointmentAd { get; set; }

        public List<MComplaintAd>mComplaintAds { get; set;}

        public MComplaintAd mComplaintAd { get; set; }

       public List<MDoctorAd> mDoctorAds { get; set; }

        public MDoctorAd MDoctorAd { get; set; }

        public MMedicineAd MMedicineAd { get; set; }

        public List<MMedicineAd> MedicineAds { get;set; }

        public MPatient mPatient { get; set; }
        public List<MPatient> mPatients { get; set; }

        public MShedule MShedule { get; set; }

        public List<MShedule> mShedules { get; set; }

        public List<MDepartment> mDepartments { get; set; }

        public MDepartment MDepartment { get; set; }


        public List<MDriverAd> mDriverAds { get; set; }

        public MDriverAd MDriverAd { get; set; }

        public List<UpdateDO> updateDOs { get; set; }

        public UpdateDO UpdateDO { get; set; }

        public RoleDO RoleDO { get; set; }
        public List<RoleDO> RoleDOs { get; set; }

        //public DateTime TodayDate { get; set; }
    }
}