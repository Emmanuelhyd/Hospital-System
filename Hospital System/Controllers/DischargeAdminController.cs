using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;
using Hospital_System.BAL;
using Hospital_System.DAL;
using System.Reflection;

namespace Hospital_System.Controllers
{
    public class DischargeAdminController : Controller
    {
        DischargeAdDAL dischargeDAL;
        DischargeAdBAL dischargeBAL = new DischargeAdBAL();
        // GET: DischargeAdmin
        public ActionResult DischargeListAd()
        {

            DischargeDo dischargeDo = new DischargeDo();

            List<DischargeDo> dischargeDos = new List<DischargeDo>();

            dischargeDos = dischargeBAL.DischargeListAd();
            return View(dischargeDos);

        }

        //Add Discharge 

        public ActionResult AddDischarge(DischargeDo dischargeDo)
        {
            
                var ids = 0;

                List<DischargeDo> dischargeDos = new List<DischargeDo>();


                if (dischargeDo.PatientId != 0)
                {
                dischargeDos = dischargeBAL.AddDischarge(dischargeDo);
                }
                if (dischargeDos.Count == 0)
                {
                    dischargeDAL = new DischargeAdDAL();
                    if (dischargeDo.PatientId == 0)
                    {
                        ids = dischargeDAL.DischargeId();
                    }
                dischargeDo.PatientId = ids + 1;

                    return View(dischargeDo);
                }
                else
                {
                    return RedirectToAction("DischargeListAd", dischargeDos);
                }
        }

        //Discharge Edit

        public ActionResult DischargeEdit(int PatientId)
        {
            if (PatientId <= 0)
                return HttpNotFound();

            DischargeDo dischargeDo = new DischargeDo();
            dischargeDo = dischargeBAL.DischargeEdit(PatientId);
            if (dischargeDo.PatientId != 0)
            {

                return View("AddDischarge", dischargeDo);
            }
            else
            {
                return RedirectToAction("DischargeListAd", "DischargeAdmin");

            }
        }

        //discharge delete
        public ActionResult DischargeDelete(int PatientId)
        {
            List<DischargeDo> dischargeDos = new List<DischargeDo>();

            dischargeDos = dischargeBAL.DischargeDelete(PatientId);
            return RedirectToAction("DischargeListAd", "DischargeAdmin");
        }

    }
}