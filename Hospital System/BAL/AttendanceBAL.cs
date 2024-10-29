using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class AttendanceBAL
    {
        AttendanceDAL attendanceDAL=new AttendanceDAL();

        //List
        public List<AttendanceDo> AttendanceList()
        {
            return attendanceDAL.AttendanceList();
        }

        //Add Attendance 

        public List<AttendanceDo> AddAttendance(AttendanceDo attendanceDo)
        {
            List<AttendanceDo> attendanceDos = new List<AttendanceDo>();
            attendanceDos = attendanceDAL.AddAttendance(attendanceDo);
            return attendanceDos;
        }

        //Attendance edit
        public AttendanceDo AttendanceEdit(int Id)
        {
            AttendanceDo attendanceDos = attendanceDAL.AttendanceEdit(Id);

            return attendanceDos;
        }
        //Attendance delete
        public List<AttendanceDo> AttendanceDelete(int Id)
        {
            List<AttendanceDo> attendanceDos = attendanceDAL.AttendanceDelete(Id);
            return attendanceDos;
        }

    }
}