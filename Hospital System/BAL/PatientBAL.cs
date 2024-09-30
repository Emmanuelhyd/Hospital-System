using Hospital_System.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Hospital_System.Models;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;



namespace Hospital_System.BAL
{
    public class PatientBAL
    {


        Patient1 patient = new Patient1();




        public string Login(Patients patients)
        {

            return patient.Login(patients);

        }



        public string Updateprofile(Patients patients)
        {
            string loggedInUsername = HttpContext.Current.Session["Username"] as string; // Retrieve username from session

            if (!string.Equals(patients.UserName, loggedInUsername, StringComparison.OrdinalIgnoreCase))
            {
                return "Unauthorized: You can only update your own profile.";
            }

            return patient.Updateprofile(patients);
        }

        public string Insertprofile(Patients patients)
        {
            string res = patient.Insertprofile(patients);
            return res;
        }

        public int GetDepartmentCount() => patient.GetDepartmentCount();
        public int GetDoctorCount() => patient.GetDoctorCount();
        public int GetPatientCount() => patient.GetPatientCount();
        public int GetAmbulanceCount() => patient.GetAmbulanceCount();
        public int GetDriverCount() => patient.GetDriverCount();
        public int GetMedicineCount(decimal patientId) => patient.GetMedicineCount(patientId);
        public int GetActiveAppointmentsCount() => patient.GetActiveAppointmentsCount();
        public int GetPendingAppointmentsCount() => patient.GetPendingAppointmentsCount();


        public List<Ambulance> GetAmbulances()
        {
            return patient.GetAmbulances();
        }

        public List<AmbulanceDriver> GetAmbulanceDrivers()
        {
            return patient.GetAmbulanceDrivers();
        }

        public AmbulanceDriver GetdriverId (int DriverId)
        {

            return patient.GetdriverId(DriverId);
        }

        public List<Doctor> GetDoctors()
        {
            return patient.GetDoctors();
        }

        public Doctor GetDoctorsId(int DoctorId)
        {
            return patient.GetDoctorsId(DoctorId);
        }


        public List<Medicine> GetMedicines(decimal patientId)
        {
            return patient.GetMedicines(patientId);
        }

        public string Changepassword(Patients patients)
        {
            string res = patient.Changepassword(patients);
            return res;
        }

        public string Forgotpassword(Patients patients)

        {
            string res = patient.Forgotpassword(patients);
            return res;
        }


        //public List<Medicine> GetPrecList(int patientId)
        //{
        //    return patient.GetPrecList(patientId);
        //}
























    }

}
