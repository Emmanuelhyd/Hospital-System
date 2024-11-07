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
using System.Security.Cryptography;
using Hospital_System.Dash;
using System.Web.Security;

namespace Hospital_System.Controllers
{
    
    public class RolesAdminController : Controller
    {
        RoleDAL roleDAL;
        RoleBAL roleBAL=new RoleBAL();
        AdminBAL adminBAL = new AdminBAL();

        // GET: RolesAdmin
        public ActionResult RolesList()
        {
            RoleDO roleDO = new RoleDO();
            List<RoleDO> roleDOs = new List<RoleDO>();

            roleDOs = roleBAL.RolesList();

            var role = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                RoleDOs = roleDOs
            };


            return View(role);
        }


        public ActionResult AddRole(RoleDO roleDo)
        {
            var ids = 0;

            List<RoleDO> roleDos = new List<RoleDO>();


            if (roleDo.Id != 0)
            {
                roleDos = roleBAL.AddRole(roleDo);
            }
            else if (roleDos.Count == 0)
            {
                roleDAL = new RoleDAL();
                if (roleDo.Id == 0)
                {
                    ids = roleDAL.RoleId();
                }
                roleDo.Id = ids + 1;


                var role = new DashboardDetails
                {
                    Adminmenus = adminBAL.GetAdminmenus(),
                    RoleDO = roleDo
                };



                return View(role);
            }


            return RedirectToAction("RolesList", roleDos);



        }

        //Edit roe

        public ActionResult RoleEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            RoleDO roleDO = new RoleDO();
            roleDO = roleBAL.RoleEdit(Id);

            var role = new DashboardDetails
            {
                Adminmenus = adminBAL.GetAdminmenus(),
                RoleDO = roleDO
            };


            if (roleDO.Id != 0)
            {

                return View("AddRole", role);
            }
            else
            {
                return RedirectToAction("RolesList", "RoleAdmin");

            }
        }


        //Delete Role

        public ActionResult RoleDelete(int Id)
        {
            List<RoleDO> roleDOs = new List<RoleDO>();

            roleDOs = roleBAL.RoleDelete(Id);


            return RedirectToAction("RolesList", "RoleAdmin");
        }

    }
}