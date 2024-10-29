using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class NurseBAL
    {

        NurseDAL nurseDAL = new NurseDAL();

        public List<Nurse> GetNurses()
        {
            return nurseDAL.GetNurses();
        }
        public Nurse NurseDetails(int NurseId)
        {
            return nurseDAL.NurseDetails(NurseId);

        }
    }
}