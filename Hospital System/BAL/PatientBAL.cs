﻿using Hospital_System.DAL;
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
            string res = patient.Updateprofile(patients);
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

        public string Changepassword(Patients patients)
        {
            string res = patient.Changepassword(patients);
            return res;
        }

        public Complain EEdit(int Id)
        {
            //Complain comp = new Complain();
            Complain comp = patient.EEdit(Id);
            return comp;
        }


        
    }
}


