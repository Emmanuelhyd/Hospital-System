using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class AmbulanceRBAL
    {
        AmbulanceRDAL ambulanceRDAL=new AmbulanceRDAL();

        public List<AmbulanceDo> AmbList()
        {
            return ambulanceRDAL.AmbList();
        }

        //Add Ambulance Admin 

        public List<AmbulanceDo> AddAmb(AmbulanceDo ambulanceDo)
        {
            List<AmbulanceDo> ambulanceDos = new List<AmbulanceDo>();
            ambulanceDos = ambulanceRDAL.AddAmb(ambulanceDo);
            return ambulanceDos;
        }

        //Ambulance edit
        public AmbulanceDo AmbEdit(int Id)
        {
            AmbulanceDo ambulanceDo = ambulanceRDAL.AmbEdit(Id);

            return ambulanceDo;
        }
        //Ambulance delete
        public List<AmbulanceDo> AmbDelete(int Id)
        {
            List<AmbulanceDo> ambulanceDos = ambulanceRDAL.AmbDelete(Id);
            return ambulanceDos;
        }
    }
}