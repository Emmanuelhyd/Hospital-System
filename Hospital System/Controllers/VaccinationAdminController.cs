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
    public class VaccinationAdminController : Controller
    {
        VacineDAL vacineDAL;
        VaccineAdBAL vaccineBAL=new VaccineAdBAL();
        // GET: VaccinationAdmin
        public ActionResult VaccineListAdmin()
        {
            VaccineDo vaccineDo = new VaccineDo();
            List<VaccineDo> vaccineDos = new List<VaccineDo>();

            vaccineDos = vaccineBAL.VaccineListAdmin();
            return View(vaccineDos);
        }

        //Add Vaccine 

        public ActionResult AddVaccine(VaccineDo vaccineDo)
        {

            var ids = 0;

            List<VaccineDo> vaccineDos = new List<VaccineDo>();


            if (vaccineDo.PatientId != 0)
            {
                vaccineDos = vaccineBAL.AddVaccine(vaccineDo);
            }
            if (vaccineDos.Count == 0)
            {
                vacineDAL = new VacineDAL();
                if (vaccineDo.PatientId == 0)
                {
                    ids = vacineDAL.VaccineId();
                }
                vaccineDo.PatientId = ids + 1;

                return View(vaccineDo);
            }
            else
            {
                return RedirectToAction("VaccineListAdmin", vaccineDos);
            }
        }




        //Vaccine Edit

        public ActionResult VaccineEdit(int PatientId)
        {
            if (PatientId <= 0)
                return HttpNotFound();

            VaccineDo vaccineDo = new VaccineDo();
            vaccineDo = vaccineBAL.VaccineEdit(PatientId);
            if (vaccineDo.PatientId != 0)
            {

                return View("AddVaccine", vaccineDo);
            }
            else
            {
                return RedirectToAction("VaccineListAdmin", "VaccinationAdmin");

            }
        }

        //Inpatient Delete

        public ActionResult VaccineDelete(int PatientId)
        {
            List<VaccineDo> vaccineDos = new List<VaccineDo>();

            vaccineDos = vaccineBAL.VaccineDelete(PatientId);
            return RedirectToAction("VaccineListAdmin", "VaccinationAdmin");
        }

    }
}