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
    public class VaccinationController : Controller
    {

        VaccineBAL vaccineBAL = new VaccineBAL();
        // GET: Vaccination
        [HttpGet]
        public ActionResult Vaccine()
        {
            var vaccine = new Vaccines
            {
                VaccineTypesList = new SelectList(GetVaccineTypes(), "Value", "Text"),
                DosageList = new SelectList(GetDosage(),"Value","Text"),
                StatusList = new SelectList(Getstatus(),"Value","Text")
            };

            return View(vaccine);
        }

        [HttpPost]
        public ActionResult Vaccine(Vaccines vaccines)
        {
            string res = vaccineBAL.Vaccination(vaccines);
            if(res=="Slot Booked")
            {
                TempData["Message"] = "Slot Booked Successfully";
                return RedirectToAction("VaccineList");
            }

            TempData["Message"] = "Error Occured";
            return View(res);
        }



        private IEnumerable<SelectListItem>GetVaccineTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = "Child Vaccine",Text="Child Vaccine"},
                new SelectListItem{Value = "Adult Vaccine",Text="Adult Vaccine"},
                new SelectListItem{Value = "COVID Vaccine",Text="COVID Vaccine"},
                new SelectListItem{Value = "Other Vaccine",Text="Other Vaccine"}
            };
 
        }

        private IEnumerable<SelectListItem> GetDosage()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = "1st Dose",Text="1st Dose"},
                new SelectListItem{Value = "2nd Dose",Text="2nd Dose"},
                new SelectListItem{Value = "Booster",Text="Booster"},
               
            };

        }

        private IEnumerable<SelectListItem> Getstatus()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value="Completed",Text="Completed"},
                new SelectListItem{Value="Pending ",Text="Pending"},
                 new SelectListItem{Value="Canceled",Text="Canceled"}

            };
        }



        public ActionResult VaccineList()
        {
            var list = vaccineBAL.VaccinesList();
            return View(list);
        }


        public ActionResult VaccinesById(string vaccineId)
        {
            Vaccines vaccines = vaccineBAL.vac(vaccineId);
            if(vaccines ==null)
            {
                return RedirectToAction("VaccineList");

            }

            return View(vaccines);
        }



        public ActionResult AddVaccine(Vaccines vaccine)
        {

            var ids = 0;

            List<Vaccines> vaccines = new List<Vaccines>();


            if (vaccine.PatientId != 0)
            {
                vaccines = vaccineBAL.AddVaccine(vaccine);
            }
            if (vaccines.Count == 0)
            {
                VaccineDAL vaccine1 = new VaccineDAL();
                if (vaccine.PatientId == 0)
                {
                    ids = vaccine1.VaccineId();
                }
                vaccine.PatientId = ids + 1;

                return View(vaccine);
            }
            else
            {
                return RedirectToAction("VaccineList", "Vaccination");
            }
        }



    }
}