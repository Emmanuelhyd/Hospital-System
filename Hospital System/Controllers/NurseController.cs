using Hospital_System.BAL;
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
    }
}