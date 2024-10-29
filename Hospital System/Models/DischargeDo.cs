using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class DischargeDo
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Reason { get; set; }
        public string Findings { get; set; }
        public string Labreports { get; set; }
        public string ProcedureandTreatment { get; set; }
        public string FurtherInstruction { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeDate { get; set; }
        public string TreatmentDuration { get; set; }
        public string DischargeAmount { get; set; }
        public string FollowUp { get; set; }
    }
}