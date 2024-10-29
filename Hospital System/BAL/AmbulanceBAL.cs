using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class AmbulanceBAL
    {

        AmbulanceDAL ambulancedal = new AmbulanceDAL();

        public List<AmbulanceDetails> GetAmbulanceDetails()
        {
            return ambulancedal.GetAmbulanceDetails();
        }
    }
}