using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class VaccineBAL
    {
        VaccineDAL vaccineDAL = new VaccineDAL();

        public string Vaccination(Vaccines vaccines)
        {
            return vaccineDAL.Vaccination(vaccines);

        }


        public List<Vaccines> VaccinesList(string searchvalue)
        {

            return vaccineDAL.VaccinesList(searchvalue);

        }

        public Vaccines vac(string vaccineId)
        {
            return vaccineDAL.vac(vaccineId);
        }
    }
}