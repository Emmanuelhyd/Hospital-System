using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;


namespace Hospital_System.BAL
{
    public class InPatientAdBAL
    {
       InPatientAdDAL inPatientDAL=new InPatientAdDAL();

        //Inpatient List

        public List<MInPatient> InPatientListAd()
        {
            return inPatientDAL.InPatientListAd();
        }

        //Add Inpatient 

        public List<MInPatient> AddInpatient(MInPatient mInPatient)
        {
            List<MInPatient> mInPatients = new List<MInPatient>();
            mInPatients = inPatientDAL.AddInpatient(mInPatient);
            return mInPatients;
        }

        //Inpatient edit
        public MInPatient InPatientEdit(int PatientId)
        {
            MInPatient mInPatients = inPatientDAL.InPatientEdit(PatientId);

            return mInPatients;
        }
        //Inpatient delete
        public List<MInPatient> InPatientDelete(int PatientId)
        {
            List<MInPatient> mInPatients = inPatientDAL.InPatientDelete(PatientId);
            return mInPatients;
        }

        //public MInPatient GetMInPatient(int PatientId)
        //{
        //    return inPatientDAL.GetInPatient(PatientId);
        //}
    }
}