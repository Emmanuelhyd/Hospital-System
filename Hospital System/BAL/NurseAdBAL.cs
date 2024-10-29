using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class NurseAdBAL
    {
        NurseAdDAL nurseAdDAL=new NurseAdDAL();


        public List<NurseDo> NurseList()
        {
            return nurseAdDAL.NurseList();
        }

        //Add Nurse 

        public List<NurseDo> AddNurse(NurseDo nurseDo)
        {
            List<NurseDo> nurseDos = new List<NurseDo>();
            nurseDos = nurseAdDAL.AddNurse(nurseDo);
            return nurseDos;
        }

        //Nurse edit
        public NurseDo NurseEdit(int NurseId)
        {
            NurseDo nurseDos = nurseAdDAL.NurseEdit(NurseId);

            return nurseDos;
        }
        //NUrse delete
        public List<NurseDo> NurseDelete(int NurseId)
        {
            List<NurseDo> nurseDos = nurseAdDAL.NurseDelete(NurseId);
            return nurseDos;
        }

    }
}