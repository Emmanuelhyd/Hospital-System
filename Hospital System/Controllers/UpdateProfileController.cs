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
    public class UpdateProfileController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: UpdateProfile
        public ActionResult UpdateList()
        {
            UpdateDO updateDO = new UpdateDO();
            List<UpdateDO> updateDOs = new List<UpdateDO>();

            updateDOs = adminBAL.UpdateList();
            return View(updateDOs);
        }

        //Add Profile

        public ActionResult AddProfile(UpdateDO updateDO)
        {
            var ids = 0;

            List<UpdateDO> updateDOs = new List<UpdateDO>();


            if (updateDO.PatientId != 0)
            {
                updateDOs = adminBAL.AddProfile(updateDO);
            }
            if (updateDOs.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (updateDO.PatientId == 0)
                {
                    ids = adminDAL.ProfileId();
                }
                updateDO.PatientId = ids + 1;

                return View(updateDO);
            }
            else
            {
                return RedirectToAction("UpdateList", updateDOs);
            }
        }

        public ActionResult ProfileEdit(int PatientId)
        {
            if (PatientId <= 0)
                return HttpNotFound();

            UpdateDO updateDO = new UpdateDO();

            updateDO = adminBAL.ProfileEdit(PatientId);

            if (updateDO.PatientId != 0)
            {

                return View("AddProfile", updateDO);
            }
            else
            {
                return RedirectToAction("UpdateList", "UpdateProfile");

            }
        }

        public ActionResult ProfileDelete(int PatientId)
        {
            List<UpdateDO> updateDOs = new List<UpdateDO>();

            updateDOs = adminBAL.ProfileDelete(PatientId);
            return RedirectToAction("UpdateList", "UpdateProfile");
        }


    }
}
