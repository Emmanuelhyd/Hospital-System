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
using Hospital_System.Dash;

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

            var update = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                updateDOs = updateDOs
            };

            return View(update);
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

                var role = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    UpdateDO = updateDO
                };



                return View(role);
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

            var role = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                UpdateDO = updateDO
            };



            if (updateDO.PatientId != 0)
            {

                return View("AddProfile", role);
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
