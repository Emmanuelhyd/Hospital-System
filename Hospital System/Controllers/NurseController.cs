using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class NurseController : Controller
    {
        NurseBAL nurseBAL= new NurseBAL();
        // GET: Nurse
        public ActionResult GetNurses()
        {
           var nurse= nurseBAL.GetNurses();
           return View(nurse);

        }

        public ActionResult NurseDetails(int NurseId)
        {
            Nurse nurse = nurseBAL.NurseDetails(NurseId);
            if(nurse==null )
            {
                return RedirectToAction("GetNurses");
            }
            return View(nurse);
        }

        //add
        public ActionResult AddNurse(Nurse nurse)
        {

            var ids = 0;

            List<Nurse> nurses = new List<Nurse>();


            if (nurse.NurseId != 0)
            {
                nurses = nurseBAL.AddNurse(nurse);
            }
            if (nurses.Count == 0)
            {
                NurseDAL nurse1 = new NurseDAL();
                if (nurse.NurseId == 0)
                {
                    ids = nurse1.NurseId();
                }
                nurse.NurseId = ids + 1;

                return View(nurse);
            }
            else
            {
                return RedirectToAction("GetNurses", "Nurse");
            }
        }


    }
}
