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
    public class AttendanceAdminController : Controller
    {

        AttendanceDAL attendanceDAL;
        AttendanceBAL attendanceBAL=new AttendanceBAL();
        // GET: AttendanceAdmin
        public ActionResult AttendanceList()
        {
            AttendanceDo attendanceDo = new AttendanceDo();
            List<AttendanceDo> attendanceDos = new List<AttendanceDo>();

            attendanceDos = attendanceBAL.AttendanceList();
            return View(attendanceDos);
        }

        //add attendance

        public ActionResult AddAttendance(AttendanceDo attendanceDo)
        {
            var ids = 0;

            List<AttendanceDo> attendanceDos = new List<AttendanceDo>();


            if (attendanceDo.Id != 0)
            {
                attendanceDos = attendanceBAL.AddAttendance(attendanceDo);
            }
            if (attendanceDos.Count == 0)
            {
                attendanceDAL = new AttendanceDAL();
                if (attendanceDo.Id == 0)
                {
                    ids = attendanceDAL.AttendanceId();
                }
                attendanceDo.Id = ids + 1;

                return View(attendanceDo);
            }
            else
            {
                return RedirectToAction("AttendanceList", attendanceDos);
            }


        }

        //Attendance Edit

        public ActionResult AttendanceEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            AttendanceDo attendanceDo = new AttendanceDo();
            attendanceDo = attendanceBAL.AttendanceEdit(Id);
            if (attendanceDo.Id != 0)
            {

                return View("AddAttendance", attendanceDo);
            }
            else
            {
                return RedirectToAction("AtendanceList", "AttendanceAdmin");

            }
        }

        //Attenance Delete
        
        public ActionResult AttendanceDelete(int Id)
        {
            List<AttendanceDo> attendanceDos = new List<AttendanceDo>();

            attendanceDos = attendanceBAL.AttendanceDelete(Id);
            return RedirectToAction("AttendanceList", "AttendanceAdmin");
        }

    }
}