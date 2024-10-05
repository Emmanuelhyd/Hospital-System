﻿using System;
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

namespace Hospital_System.Controllers
{
    public class DepartmentController : Controller
    {
        AdminDAL adminDAL;
        AdminBAL adminBAL = new AdminBAL();
        // GET: Department
        public ActionResult DepartmentList(string dep)
        {
            MDepartment mDepartments = new MDepartment();
            List<MDepartment> mDepartment = new List<MDepartment>();

            mDepartment = adminBAL.DepartmentList(dep);
            return View(mDepartment);
        }

        



        public ActionResult AddDepartment(MDepartment mDepartment)
        {
            var ids = 0;

            List<MDepartment> mDepartments = new List<MDepartment>();


            if (mDepartment.Id != 0)
            {
                mDepartments = adminBAL.AddDepartment(mDepartment);
            }
            if (mDepartments.Count == 0)
            {
                adminDAL = new AdminDAL();
                if (mDepartment.Id == 0)
                {
                    ids = adminDAL.DepartmentId();
                }
                mDepartment.Id = ids + 1;

                return View(mDepartment);
            }
            else
            {
                return RedirectToAction("DepartmentList", mDepartments);
            }


        }

        public ActionResult DLEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            MDepartment mDepartment = new MDepartment();
            mDepartment = adminBAL.DLEdit(Id);
            if (mDepartment.Id != 0)
            {

                return View("AddDepartment", mDepartment);
            }
            else
            {
                return RedirectToAction("DepartmentList", "Department");

            }
        }


        public ActionResult DLDelete(int Id)
        {
            List<MDepartment> mDepartments = new List<MDepartment>();

            mDepartments = adminBAL.DLDelete(Id);
            return RedirectToAction("DepartmentList", "Department");
        }
    }
}