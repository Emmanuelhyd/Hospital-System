using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class ConsultBAL
    {
        ConsultDAL consultdal = new ConsultDAL();

        public List<HospPatient> CHospPatient()
        {
            return consultdal.CHospPatient();
        }


        public List<HospPatient> ConsultDoc(string DoctorName)
        {
            return consultdal.ConsultDoc(DoctorName);
        }
    }
}