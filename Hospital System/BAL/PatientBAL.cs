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


        //public string Loginn(Patients patients)
        //{


        //    string res = patient.Loginn(patients);

        //    return res;
        //}

        public string Login(Custom custom)
        {

            return patient.Login(custom);

        }

        public string Updateprofilee(Patients patients)
        {
            string res = patient.Updateprofilee(patients);
            return res;
        }





        public int GetDepartmentCount() => patient.GetDepartmentCount();
        public int GetDoctorCount() => patient.GetDoctorCount();
        public int GetPatientCount() => patient.GetPatientCount();
        public int GetAmbulanceCount() => patient.GetAmbulanceCount();
        public int GetDriverCount() => patient.GetDriverCount();
        public int GetMedicineCount() => patient.GetMedicineCount();
        public int GetActiveAppointmentsCount() => patient.GetActiveAppointmentsCount();
        public int GetPendingAppointmentsCount() => patient.GetPendingAppointmentsCount();


        public List<Ambulance> GetAmbulances()
        {
            return patient.GetAmbulances();
        }
        public List<Department> GetDepartments()
        {
            return patient.GetDepartments();
        }
        public List<AmbulanceDriver> GetAmbulanceDrivers()
        {
            return patient.GetAmbulanceDrivers();
        }

        public List<Doctor> GetDoctors()
        {
            return patient.GetDoctors();
        }

        public List<Medicine> GetMedicines()
        {
            return patient.GetMedicines();
        }




        public string Complaint(Complain complain)
        {
            string res = patient.Complaint(complain);
            return res;
        }

        public List<Complain> GetComplains(string searchvalue)
        {
            return patient.GetComplains(searchvalue);
        }

        public string Changepassword(Custom custom)
        {
            string res = patient.Changepassword(custom);
            return res;
        }
        public string EditComplain(Complain complain)
        {
            string res = patient.EditComplain(complain);
            return res;
        }
    }
}


