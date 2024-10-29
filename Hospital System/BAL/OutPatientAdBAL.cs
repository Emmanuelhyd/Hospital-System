using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;


namespace Hospital_System.BAL
{
    public class OutPatientAdBAL
    {
        OutPatientAdDAL outPatientDAL=new OutPatientAdDAL();

        public List<MInPatient> OutPatientList()
        {
            return outPatientDAL.OutPatientList();
        }

        //Add outpatient 

        public List<MInPatient> AddOutPatient(MInPatient mInPatient)
        {
            List<MInPatient> mInPatients = new List<MInPatient>();
            mInPatients = outPatientDAL.AddOutPatient(mInPatient);
            return mInPatients;
        }

        //outpatient edit
        public MInPatient OutPatientEdit(int PatientId)
        {
            MInPatient mInPatients = outPatientDAL.OutPatientEdit(PatientId);

            return mInPatients;
        }
        //outpatient delete
        public List<MInPatient> OutPatientDelete(int PatientId)
        {
            List<MInPatient> mInPatients = outPatientDAL.OutPatientDelete(PatientId);
            return mInPatients;
        }

    }
}