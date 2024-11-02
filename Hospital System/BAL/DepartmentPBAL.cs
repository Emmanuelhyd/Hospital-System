using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;


namespace Hospital_System.BAL
{
    public class DepartmentPBAL
    {
        DepartmentPDAL departmentPDAL=new DepartmentPDAL();

        public List<MDepartment> DepList()
        {
            return departmentPDAL.DepList();
        }
    }
}