using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;


namespace Hospital_System.BAL
{
    public class DischargeAdBAL
    { 
        DischargeAdDAL dischargeDAL = new DischargeAdDAL();
        
        public List<DischargeDo> DischargeListAd()
        {
            return dischargeDAL.DischargeListAd();
        }
        //Add Discharge

        public List<DischargeDo> AddDischarge(DischargeDo dischargeDo)
        {
            List<DischargeDo> dischargeDos = new List<DischargeDo>();
            dischargeDos = dischargeDAL.AddDischarge(dischargeDo);
            return dischargeDos;
        }
        //Discharge edit
        public DischargeDo DischargeEdit(int PatientId)
        {
            DischargeDo dischargeDo = dischargeDAL.DischargeEdit(PatientId);

            return dischargeDo;
        }
        // delete Discharge
        public List<DischargeDo> DischargeDelete(int PatientId)
        {
            List<DischargeDo> dischargeDos = dischargeDAL.DischargeDelete(PatientId);
            return dischargeDos;
        }


    }
}