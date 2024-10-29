using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Hospital_System.Models;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;

namespace Hospital_System.Controllers
{
    public class NurseAdminController : Controller
    {
        NurseAdDAL nurseAdDAL;
        NurseAdBAL nurseBAL=new NurseAdBAL();
        // GET: NurseAdmin
        public ActionResult NurseList()
        {
            NurseDo nurseDo = new NurseDo();
            List<NurseDo> nurseDos = new List<NurseDo>();

            nurseDos = nurseBAL.NurseList();
            return View(nurseDos);
        }

        //add nurse

        public ActionResult AddNurse(NurseDo nurseDo)
        {
            var ids = 0;

            List<NurseDo> nurseDos = new List<NurseDo>();


            if (nurseDo.NurseId != 0)
            {
                nurseDos = nurseBAL.AddNurse(nurseDo);
            }
            if (nurseDos.Count == 0)
            {
                nurseAdDAL = new NurseAdDAL();
                if (nurseDo.NurseId == 0)
                {
                    ids = nurseAdDAL.NursesId();
                }
                nurseDo.NurseId = ids + 1;

                return View(nurseDo);
            }
            else
            {
                return RedirectToAction("NurseList", nurseDos);
            }


        }

        //Nurse Edit

        public ActionResult NurseEdit(int NurseId)
        {
            if (NurseId <= 0)
                return HttpNotFound();

            NurseDo nurseDo = new NurseDo();
            nurseDo = nurseBAL.NurseEdit(NurseId);
            if (nurseDo.NurseId != 0)
            {

                return View("AddNurse", nurseDo);
            }
            else
            {
                return RedirectToAction("NurseList", "NurseAdmin");

            }
        }

        //Nurse Delete

        public ActionResult NurseDelete(int NurseId)
        {
            List<NurseDo> nurseDos = new List<NurseDo>();

            nurseDos = nurseBAL.NurseDelete(NurseId);
            return RedirectToAction("NurseList", "NurseAdmin");
        }
    }
}