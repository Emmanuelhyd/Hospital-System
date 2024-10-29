using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
  
    public class AmbulanceAdBAL
    {
        AmbulanceAdBAL ambulanceAdDAL = new AmbulanceAdBAL();

        public List<AmbulanceDo> AmbulanceListAdmin()
        {
            return ambulanceAdDAL.AmbulanceListAdmin();
        }

        //Add Ambulance Admin 

        public List<AmbulanceDo> AddAmbulanceAdmin(AmbulanceDo ambulanceDo)
        {
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();
            ambulanceDos = ambulanceAdDAL.AddAmbulanceAdmin(ambulanceDo);
            return ambulanceDos;
        }

        //Ambulance edit
        public AmbulanceDo AmbulanceEdit(int Id)
        {
            AmbulanceDo ambulanceDo = ambulanceAdDAL.AmbulanceEdit(Id);

            return ambulanceDo;
        }
        //Ambulance delete
        public List<AmbulanceDo> AmbulanceDelete(int Id)
        {
            List<AmbulanceDo> ambulanceDos = ambulanceAdDAL.AmbulanceDelete(Id);
            return ambulanceDos;
        }

    }
}