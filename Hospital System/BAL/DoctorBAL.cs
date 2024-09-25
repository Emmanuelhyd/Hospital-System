using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;


namespace Hospital_System.BAL
{
    public class DoctorBAL
    {
        DoctorDAL doctorDAL = new DoctorDAL();

        //public string NewDoctor(Doctors doctors)
        //{
        //    string res = doctorDAL.NewDoctor(doctors);
        //    return res;
        //}

        public List<Doctor> GetDoctors(string searchvalue)
        {
           
           return doctorDAL.GetDoctors(searchvalue);
        }

      

        public List<MPrescription> GetPrecList()
        {
            return doctorDAL.GetPrecList();
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




    }
}