using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
    public class ConsultantAdBAL
    {
        ConsultantDAL consultantDAL=new ConsultantDAL();
        //List
        public List<ConsultantDo> ConsultantList()
        {
            return consultantDAL.ConsultantList();
        }



        //Add Consultant 

        public List<ConsultantDo> AddConsultant(ConsultantDo consultantDo)
        {
            List<ConsultantDo> consultantDos = new List<ConsultantDo>();
            consultantDos = consultantDAL.AddConsultant(consultantDo);
            return consultantDos;
        }

        //Consultant edit
        public ConsultantDo ConsultantEdit(int PatientId)
        {
            ConsultantDo consultantDos = consultantDAL.ConsultantEdit(PatientId);

            return consultantDos;
        }
        //Consltant delete
        public List<ConsultantDo> ConsultantDelete(int PatientId)
        {
            List<ConsultantDo> consultantDos = consultantDAL.ConsultantDelete(PatientId);
            return consultantDos;
        }
    }
}