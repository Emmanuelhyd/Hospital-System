using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;
using Hospital_System.Viewmodel;


namespace Hospital_System.BAL
{
    public class DoctorBAL
    {
        DoctorDAL doctorDAL = new DoctorDAL();
        Patient1 patient1 = new Patient1();

        //public string NewDoctor(Doctors doctors)
        //{
        //    string res = doctorDAL.NewDoctor(doctors);
        //    return res;
        //}

        public List<Doctor> GetDoctors(string searchvalue)
        {

            return doctorDAL.GetDoctors(searchvalue);
        }




        public List<MAppointment> GetAppointmentList(string searchvalue)
        {
            return doctorDAL.GetAppointmentList(searchvalue);
        }

        public string BookAppointment(MAppointment mAppointment)
        {
            string res = doctorDAL.BookAppointment(mAppointment);
            return res;
        }




        public List<MComplaint> RegisterComplaint(MComplaint mComplaint)
        {
            List<MComplaint> mComplaints = new List<MComplaint>();
            mComplaints = doctorDAL.RegisterComplaint(mComplaint);
            return mComplaints;
        }

        public List<MComplaint> ComplaintList()
        {
            return doctorDAL.ComplaintList();
        }

        public MComplaint CEdit(int Id)
        {
            MComplaint mComplaints = doctorDAL.CEdit(Id);

            return mComplaints;
        }


        public List<Medicine> GetMedicines(int Id)
        {
            return patient1.GetMedicines(Id);

        }

        //appointmentList
        public List<MAppointmentAd> BookList()
        {
            return doctorDAL.BookList();
        }

        //Add Appointment

        public List<MAppointmentAd> AddBook(MAppointmentAd mAppointmentAd)
        {
            List<MAppointmentAd> mAppointmentAds = new List<MAppointmentAd>();
            mAppointmentAds = doctorDAL.AddBook(mAppointmentAd);
            return mAppointmentAds;
        }

    }
}