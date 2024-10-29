using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AdminPages.Models;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class AdminBAL
    {
        AdminDAL adminDAL = new AdminDAL();

        //DashBoard

        public int GetMDepartmentCount() => adminDAL.GetMDepartmentCount();
        public int GetMDoctorCount() => adminDAL.GetMDoctorCount();
        public int GetMPatientCount() => adminDAL.GetMPatientCount();
        public int GetMAmbulanceCount() => adminDAL.GetMAmbulanceCount();
        public int GetMAnnouncementCount() => adminDAL.GetMAnnouncementCount();
        public int GetMAppointmentCount() => adminDAL.GetMAppointmentCount();

        public int GetMComplaintAdCount() => adminDAL.GetMComplaintAdCount();
        public int GetMDriverAdCount() => adminDAL.GetMDriverAdCount();
        public int GetMMedicineAdCount() => adminDAL.GetMMedicineAdCount();
        public int GetMSheduleCount() => adminDAL.GetMSheduleCount();





        //UpdateProfile List
        public List<UpdateDO> UpdateList()
        {
            return adminDAL.UpdateList();
        }

        //add profile

        public List<UpdateDO> AddProfile(UpdateDO updateDO)
        {
            List<UpdateDO> updateDOs = new List<UpdateDO>();
            updateDOs = adminDAL.AddProfile(updateDO);
            return updateDOs;
        }

        //Edit Profile

        public UpdateDO ProfileEdit(int PatientId)
        {
            UpdateDO updateDOs = adminDAL.ProfileEdit(PatientId);

            return updateDOs;
        }

        //Profile Delete   

        public List<UpdateDO> ProfileDelete(int PatientId)
        {
            List<UpdateDO> updateDOs = adminDAL.ProfileDelete(PatientId);
            return updateDOs;
        }




        //Department list
        public List<MDepartment> DepartmentList(string dep)
        {
            return adminDAL.DepartmentList(dep);
        }
        //add department

        public List<MDepartment> AddDepartment(MDepartment mDepartment)
        {
            List<MDepartment> mDepartments = new List<MDepartment>();
            mDepartments = adminDAL.AddDepartment(mDepartment);
            return mDepartments;
        }

        //department edit
        public MDepartment DLEdit(int Id)
        {
            MDepartment mComplaints = adminDAL.DLEdit(Id);

            return mComplaints;
        }
        // delete doctor
        public List<MDepartment> DLDelete(int Id)
        {
            List<MDepartment> mDepartments = adminDAL.DLDelete(Id);
            return mDepartments;
        }

        //DoctorList

        public List<MDoctorAd> DoctorListAd(string doc)
        {
            return adminDAL.DoctorListAd(doc);
        }
        //add doctor
        public List<MDoctorAd> AddDoctorAd(MDoctorAd mDoctorAd)
        {
            List<MDoctorAd> mDoctors = new List<MDoctorAd>();
            mDoctors = adminDAL.AddDoctorAd(mDoctorAd);
            return mDoctors;
        }

        //edir doctor
        public MDoctorAd DAEdit(int DoctorId)
        {
            MDoctorAd mDoctors = adminDAL.DAEdit(DoctorId);

            return mDoctors;
        }
        //delete doctor
        public List<MDoctorAd> DADelete(int DoctorId)
        {
            List<MDoctorAd> mDoctors = adminDAL.DADelete(DoctorId);
            return mDoctors;
        }



        //Patient List

        public List<MPatient> PatientList(string patient)
        {
            return adminDAL.PatientList(patient);
        }

        //Add patient

        public List<MPatient> AddPatientAd(MPatient mPatient)
        {
            List<MPatient> mPatients = new List<MPatient>();
            mPatients = adminDAL.AddPatientAd(mPatient);
            return mPatients;
        }

        //edit patient
        public MPatient PatientEdit(int Id)
        {
            MPatient mPatients = adminDAL.PatientEdit(Id);

            return mPatients;
        }
        //patient delete
        public List<MPatient> PatientDelete(int Id)
        {
            List<MPatient> mPatients = adminDAL.PatientDelete(Id);
            return mPatients;
        }


        //Shedule List

        public List<MShedule> SheduleList(string Shedule)
        {
            return adminDAL.SheduleList(Shedule);
        }

        //add shedule

        public List<MShedule> AddSheduleAd(MShedule mShedule)
        {
            List<MShedule> mShedules = new List<MShedule>();
            mShedules = adminDAL.AddSheduleAd(mShedule);
            return mShedules;
        }

        //edit shedule

        public MShedule SLEdit(int Id)
        {
            MShedule mShedules = adminDAL.SLEdit(Id);

            return mShedules;
        }

        //delete shedule

        public List<MShedule> SheduleDelete(int Id)
        {
            List<MShedule> mShedules = adminDAL.SheduleDelete(Id);
            return mShedules;
        }








        //announcement list
        public List<MAnnouncement> AnnouncementList(string announcement)
        {
            return adminDAL.AnnouncementList(announcement);
        }


        //Add Announcement

        public List<MAnnouncement> AddAnnouncementAd(MAnnouncement mAnnouncement)
        {
            List<MAnnouncement> mAnnouncements = new List<MAnnouncement>();
            mAnnouncements = adminDAL.AddAnnouncementAd(mAnnouncement);
            return mAnnouncements;
        }

        //edit Announcement
        public MAnnouncement ALEdit(int Id)
        {
            MAnnouncement mAnnouncement = adminDAL.ALEdit(Id);

            return mAnnouncement;
        }
        // delete announcemnet

        public List<MAnnouncement> AnnouncementDelete(int Id)
        {
            List<MAnnouncement> mAnnouncements = adminDAL.AnnouncementDelete(Id);
            return mAnnouncements;
        }

        //appointmentList
        public List<MAppointmentAd> AppointmentList(string app)
        {
            return adminDAL.AppointmentList(app);
        }

        //Add Appointment

        public List<MAppointmentAd> AddAppointmentAd(MAppointmentAd mAppointmentAd)
        {
            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();
            mAppointmentAds = adminDAL.AddAppointmentAd(mAppointmentAd);
            return mAppointmentAds;
        }

        //edit Appointment
        public MAppointmentAd AppointmentEdit(int Id)
        {
            MAppointmentAd mAppointmentAd = adminDAL.AppointmentEdit(Id);

            return mAppointmentAd;
        }
        //delete appointment
        public List<MAppointmentAd> AppointmentAdDelete(int Id)
        {
            List<MAppointmentAd> mAppointmentAds = adminDAL.AppointmentAdDelete(Id);
            return mAppointmentAds;
        }
        //Complaint List
        public List<MComplaintAd> ComplaintAdList()
        {
            return adminDAL.ComplaintAdList();
        }

        //add complaint

        public List<MComplaintAd> AddComplaintAd(MComplaintAd mComplaintAd)
        {
            List<MComplaintAd> mComplaintAds = new List<MComplaintAd>();
            mComplaintAds = adminDAL.AddComplaintAd(mComplaintAd);
            return mComplaintAds;
        }
        //Edit Complaint
        public MComplaintAd ComplaintEdit(int Id)
        {
            MComplaintAd mComplaintAds = adminDAL.ComplaintEdit(Id);

            return mComplaintAds;
        }

        //delete complaint
        public List<MComplaintAd> ComplaintDelete(int Id)
        {
            List<MComplaintAd> mComplaintAds = adminDAL.ComplaintDelete(Id);
            return mComplaintAds;
        }

        //Medicine List
        public List<MMedicineAd> MedicineAdList(string med)
        {
            return adminDAL.MedicineAdList(med);
        }
        //Add medicine
        public List<MMedicineAd> AddMedicineAd(MMedicineAd mMedicineAd)
        {
            List<MMedicineAd> mMedicineAds = new List<MMedicineAd>();
            mMedicineAds = adminDAL.AddMedicineAd(mMedicineAd);
            return mMedicineAds;
        }
        //Edit medicine
        public MMedicineAd MedicineEdit(int PatientId)
        {
            MMedicineAd mMedicineAd = adminDAL.MedicineEdit(PatientId);

            return mMedicineAd;
        }
        //delete Medicine
        public List<MMedicineAd> MedicineDelete(int PatientId)
        {
            List<MMedicineAd> mMedicineAds = adminDAL.MedicineDelete(PatientId);
            return mMedicineAds;
        }


        //Ambulance List
        public List<MAmbulance> AmbulanceListAd()
        {
            return adminDAL.AmbulanceListAd();
        }


        //Add Ambulance
        public List<MAmbulance> AddAmbulanceAd(MAmbulance mAmbulance)
        {
            List<MAmbulance> mAmbulances = new List<MAmbulance>();
            mAmbulances = adminDAL.AddAmbulanceAd(mAmbulance);
            return mAmbulances;
        }
        //Edit Ambulance
        public MAmbulance AmbulanceEdit(int Id)
        {
            MAmbulance mAmbulances = adminDAL.AmbulanceEdit(Id);

            return mAmbulances;
        }

        //delete Ambulance
        public List<MAmbulance> AmbulanceDelete(int Id)
        {
            List<MAmbulance> mAmbulances = adminDAL.AmbulanceDelete(Id);
            return mAmbulances;
        }

        //Ambulance View
        public MAmbulance Ambulance(int Id)
        {

            return adminDAL.Ambulance(Id);
        }

        //Ambulance driver List
        public List<MDriverAd> AmbulanceDriverAd(string Driver)
        {
            return adminDAL.AmbulanceDriverAd(Driver);
        }
        //add Driver

        public List<MDriverAd> AddDriverAd(MDriverAd mDriverAd)
        {
            List<MDriverAd> mDriverAds = new List<MDriverAd>();
            mDriverAds = adminDAL.AddDriverAd(mDriverAd);
            return mDriverAds;
        }
        //Edit driver
        public MDriverAd DriverEdit(int Id)
        {
            MDriverAd mDriverAds = adminDAL.DriverEdit(Id);

            return mDriverAds;
        }
        //driver delete
        public List<MDriverAd> DriverDelete(int Id)
        {
            List<MDriverAd> mDriverAds = adminDAL.DriverDelete(Id);
            return mDriverAds;
        }
        //Driver View
        public MDriverAd Ambulancedriver(int Id)
        {

            return adminDAL.Ambulancedriver(Id);
        }


        public List<Adminmenu> GetAdminmenus()
        {
            return adminDAL.GetAdminmenus();

        }
    }
}