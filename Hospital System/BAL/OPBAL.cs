using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Hospital_System.BAL
{
    public class OPBAL
    {
        OPDAL opdal = new OPDAL();


        public List<HospPatient> GetPatients()
        {
            return opdal.GetPatients();
        }

        public HospPatient OPID(int Id)
        {
            return opdal.OPID(Id);
        }

        public List<HospPatient> GetHospPatients()
        {

            return opdal.GetHospPatients();
        }

        public HospPatient PatientEdit(int Id)
        {
            return opdal.PatientEdit(Id);
        }


        public List<HospPatient> AddPatients(HospPatient hosp)
        {
               List<HospPatient> list = new List<HospPatient>();
                list = opdal.AddPatients(hosp);
                return list;
            
        }

    }
}