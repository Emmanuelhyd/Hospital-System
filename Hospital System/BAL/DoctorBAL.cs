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

        public string NewDoctor(Doctors doctors)
        {
            string res = doctorDAL.NewDoctor(doctors);
            return res;
        }

        public List<Doctors> DoctorList(string Sagar)
        {
            List<Doctors> doctors = new List<Doctors>();
            doctors= doctorDAL.DoctorList(Sagar);
            return doctors;
        }

        public Doctors DEdit(int Id)
        {
           Doctors doctors= doctorDAL.DEdit(Id);
            return doctors;
        }

        public List<Doctors> DDelete(int Id)
        {
           

            List<Doctors> res = doctorDAL.DDelete(Id);
            return res;
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

        public string RegistrationPage(MRegistration mRegistration)
        {
            string res = doctorDAL.RegistrationPage(mRegistration);
            return res;
        }
    }
}