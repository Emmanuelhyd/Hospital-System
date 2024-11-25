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

        public List<AmbulanceDetails> AddAmbulance(AmbulanceDetails ambulanceDo)
        {
            List<AmbulanceDetails> ambulanceDos = new List<AmbulanceDetails>();
            ambulanceDos = ambulancedal.AddAmbulance(ambulanceDo);
            return ambulanceDos;
        }

        //Ambulance edit
        public AmbulanceDetails AmbE(int Id)
        {
            AmbulanceDetails ambulanceDo = ambulancedal.AmbE(Id);

            return ambulanceDo;
        }

        public AmbulanceDetails AmbulanceId(int Id)
        {
            return ambulancedal.AmbulanceId(Id);
        }
    }
}