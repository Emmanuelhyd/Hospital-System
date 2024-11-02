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
using Hospital_System.Viewmodel;

namespace Hospital_System.Controllers
{
    public class DepartmentPatientController : Controller
    {
        MenuBAL menuBAL;
        DepartmentPDAL departmentPDAL;
        DepartmentPBAL departmentPBAL = new DepartmentPBAL();
        // GET: DepartmentPatient


        public ActionResult Dash()
        {
            return View();
        }

        public ActionResult DepList()
        {
            MDepartment mDepartment = new MDepartment();
            List<MDepartment> mDepartments = new List<MDepartment>();

            mDepartments = departmentPBAL.DepList();
            return View(mDepartments);
        }
    }
}