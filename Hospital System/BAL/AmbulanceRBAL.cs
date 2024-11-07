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

        public List<AmbulanceDo> AmbList(string And)
        {
            return ambulanceRDAL.AmbList(And);
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


        //List Of driver

        public List<DriverDo> DriveList(string Dri)
        {
            return ambulanceRDAL.DriveList(Dri);
        }

        //Add Driver Admin 

        public List<DriverDo> AddDrive(DriverDo driverDo)
        {
            List<DriverDo> driverDos = new List<DriverDo>();
            driverDos = ambulanceRDAL.AddDrive(driverDo);
            return driverDos;
        }

        //Driver edit
        public DriverDo DriveREdit(int Id)
        {
            DriverDo driverDo = ambulanceRDAL.DriveREdit(Id);

            return driverDo;
        }
        //Driver delete
        public List<DriverDo> DriveRDelete(int Id)
        {
            List<DriverDo> driverDos = ambulanceRDAL.DriveRDelete(Id);
            return driverDos;
        }

    }
}