using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class ConsultantDo
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName {  get; set; }
        public string Date {  get; set; }
        public string Problem { get; set; }
        public string Description {  get; set; }
        public string Address {  get; set; }
        public string Status { get; set; }
    }
}