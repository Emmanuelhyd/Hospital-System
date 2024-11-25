using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class AttendBAL
    {
        AttendDAL attendDAL = new AttendDAL();

        public List<Attend> AttendanceDetails()
        {
            return attendDAL.AttendanceDetails();
        }

        public List<Attend> AddAttend(Attend attendanceDo)
        {
            List<Attend> attendanceDos = new List<Attend>();
            attendanceDos = attendDAL.AddAttend(attendanceDo);
            return attendanceDos;
        }

        //Attendance edit
        public Attend AttendanceE(int Id)
        {
            Attend attendanceDos = attendDAL.AttendanceE(Id);

            return attendanceDos;
        }

        public Attend AttendId(int Id)
        {
            return attendDAL.AttendId(Id);
        }
    }
}