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
    public class ConsultantAdminController : Controller
    {
        ConsultantDAL consultantDAL;
        ConsultantAdBAL consultantBAL=new ConsultantAdBAL();
        // GET: ConsultantAdmin
        public ActionResult ConsultantList()
        {
            ConsultantDo consultantDo = new ConsultantDo();
            List<ConsultantDo> consultantDos = new List<ConsultantDo>();

            consultantDos = consultantBAL.ConsultantList();
            return View(consultantDos);
        }

        //add Consultant

        public ActionResult AddConsultant(ConsultantDo consultantDo)
        {
            var ids = 0;

            List<ConsultantDo> consultantDos = new List<ConsultantDo>();


            if (consultantDo.DoctorId != 0)
            {
                consultantDos = consultantBAL.AddConsultant(consultantDo);
            }
            if (consultantDos.Count == 0)
            {
                consultantDAL = new ConsultantDAL();
                if (consultantDo.DoctorId == 0)
                {
                    ids = consultantDAL.ConsultantId();
                }
                consultantDo.DoctorId = ids + 1;

                return View(consultantDo);
            }
            else
            {
                return RedirectToAction("ConsultantList", consultantDos);
            }


        }

        //Consultant Edit

        public ActionResult ConsultantEdit(int DoctorId)
        {
            if (DoctorId <= 0)
                return HttpNotFound();

            ConsultantDo consultantDo = new ConsultantDo();
            consultantDo = consultantBAL.ConsultantEdit(DoctorId);
            if (consultantDo.DoctorId != 0)
            {

                return View("AddConsultant", consultantDo);
            }
            else
            {
                return RedirectToAction("ConsultantList", "ConsultantAdmin");

            }
        }

        //Consultant Delete

        public ActionResult ConsultantDelete(int DoctorId)
        {
            List<ConsultantDo> consultantDos = new List<ConsultantDo>();

            consultantDos = consultantBAL.ConsultantDelete(DoctorId);
            return RedirectToAction("ConsultantList", "ConsultantAdmin");
        }


    }
}