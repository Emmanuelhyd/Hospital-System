using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AdminPages.Models;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class RoleBAL
    {
        RoleDAL roleDAL=new RoleDAL();

        public List<RoleDO> RolesList()
        {
            return roleDAL.RolesList();
        }
        //add Roles

        public List<RoleDO> AddRole(RoleDO roleDO)
        {
            List<RoleDO> roleDOs = new List<RoleDO>();
            roleDOs = roleDAL.AddRole(roleDO);
            return roleDOs;
        }
        //Role edit
        public RoleDO RoleEdit(int Id)
        {
            RoleDO roleDO = roleDAL.RoleEdit(Id);

            return roleDO;
        }
        // Role doctor
        public List<RoleDO> RoleDelete(int Id)
        {
            List<RoleDO> roleDOs = roleDAL.RoleDelete(Id);
            return roleDOs;
        }
    }
}