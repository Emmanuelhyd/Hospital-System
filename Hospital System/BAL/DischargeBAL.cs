using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class DischargeBAL
    {

        DischargeDAL dischargeDAL = new DischargeDAL();

        public List<DischargPatient> GetdischargPatients(DateTime? date, int? patientId)
        {

            return dischargeDAL.GetdischargPatients(date, patientId);

        }

        public DischargPatient DischargeId(int patientId)
        {
            return dischargeDAL.DischargeId(patientId);
        }
    }
}