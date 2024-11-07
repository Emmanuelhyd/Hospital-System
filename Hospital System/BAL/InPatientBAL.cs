using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class InPatientBAL
    {
        InpatientsDAL inpatientsDAL = new InpatientsDAL();

        public List<HospPatient> HospPatients()

        {

            return inpatientsDAL.HospPatients();
        }


        //public decimal TotalCharges(int ID)

        //{
        //    return inpatientsDAL.TotalCharges(ID);
        //}




        public HospPatient GetHospPatient(int Id)
        {
            return inpatientsDAL.GetHospPatient(Id);

        }

        public List<Doctor> GetDoctors()
        {
            return inpatientsDAL.GetDoctors();
        }
    }
}