using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{

   
    public class CommonBAL
    {
        CommonDAL commonDAL = new CommonDAL();
        //Common List
        public List<MInPatient> CommonList()
        {
            return commonDAL.CommonList();
        }

        //Add Discharge

        public List<MInPatient> AddCommonOP(MInPatient mInPatient)
        {
            List<MInPatient> mInPatients = new List<MInPatient>();
            mInPatients = commonDAL.AddCommonOP(mInPatient);
            return mInPatients;
        }

        //Common edit
        public MInPatient CommonEdit(int PatientId)
        {
            MInPatient mInPatient = commonDAL.CommonEdit(PatientId);

            return mInPatient;
        }
        // Common Discharge
        public List<MInPatient> CommonDelete(int PatientId)
        {
            List<MInPatient> mInPatients = commonDAL.CommonDelete(PatientId);
            return mInPatients;
        }

    }
}