using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class VaccineDo
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Age { get; set; }
        public string VaccineId { get; set; }
        public string VaccineType { get; set; }
        public string Dosage { get; set; }
        public string DateOfVaccination { get; set; }
        public string FollowupDate { get; set; }
        public string NextDueDate { get; set; }
        public string ReactionType { get; set; }
        public string Status { get; set; }
    }
}