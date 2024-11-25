using Hospital_System.BAL;
using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class AttendanceController : Controller
    {
        AttendBAL attendBAL = new AttendBAL();
        // GET: Atterndance
        public ActionResult AttendanceDetails()
        {
            var attendance = attendBAL.AttendanceDetails();
            return View(attendance);
        }


        public ActionResult AddAttend(Attend attendanceDo)
        {
            var ids = 0;

            List<Attend> attendanceDos = new List<Attend>();


            if (attendanceDo.Id != 0)
            {
                attendanceDos = attendBAL.AddAttend(attendanceDo);
            }
            if (attendanceDos.Count == 0)
            {
              AttendDAL  attendDAL = new AttendDAL();
                if (attendanceDo.Id == 0)
                {
                    ids = attendDAL.AttendanceId();
                }
                attendanceDo.Id = ids + 1;

                return View(attendanceDo);
            }
            else
            {
                return RedirectToAction("AttendanceDetails", attendanceDos);
            }


        }

        //Attendance Edit

        public ActionResult AttendanceE(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();

            Attend attendanceDo = new Attend();
            attendanceDo = attendBAL.AttendanceE(Id);
            if (attendanceDo.Id != 0)
            {

                return View("AddAttend", attendanceDo);
            }
            else
            {
                return RedirectToAction("AttendanceDetails", "Attendance");

            }
        }


        public ActionResult AttendId(int Id)
        {
            var attend = attendBAL.AttendId(Id);
            if(attend== null)
            {
                return HttpNotFound("ID not found");
            }
            return View(attend);
        }
    }
}