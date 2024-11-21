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
    public class DischargeController : Controller
    {
        DischargeBAL dischargeBAL= new DischargeBAL();
        // GET: Discharge
        public ActionResult Discharge()
        {
           

            var model = dischargeBAL.GetdischargPatients();
            return View(model);

        }

        public ActionResult DischargeId(int PatientId)
        {
            DischargPatient dischargPatient = dischargeBAL.DischargeId(PatientId);
            if(dischargPatient== null)
            {
                return View("Discharge");
            }
            return View(dischargPatient);

        }

        public ActionResult AddDischarge(DischargPatient dischargeDo)
        {

            var ids = 0;

            List<DischargPatient> dischargeDos = new List<DischargPatient>();


            if (dischargeDo.PatientId != 0)
            {
                dischargeDos = dischargeBAL.AddDischarge(dischargeDo);
            }
            if (dischargeDos.Count == 0)
            {
               DischargeDAL dischargeDAL = new DischargeDAL();
                if (dischargeDo.PatientId == 0)
                {
                    ids = dischargeDAL.DischargeId();
                }
                dischargeDo.PatientId = ids + 1;

                return View(dischargeDo);
            }
            else
            {
                return RedirectToAction("Discharge", dischargeDo);
            }
        }

        //Discharge Edit

        public ActionResult DischargeE(int PatientId)
        {
            if (PatientId <= 0)
                return HttpNotFound();

            DischargPatient dischargeDo = new DischargPatient();
            dischargeDo = dischargeBAL.DischargeE(PatientId);
            if (dischargeDo.PatientId != 0)
            {

                return View("AddDischarge", dischargeDo);
            }
            else
            {
                return RedirectToAction("Discharge", "Discharge");

            }
        }

    }
}