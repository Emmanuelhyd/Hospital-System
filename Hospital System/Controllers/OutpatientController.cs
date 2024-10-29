using Hospital_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class OutpatientController : Controller
    {
        OPBAL opBal = new OPBAL();
        // GET: Outpatient
        public ActionResult OutP()
        {
            var model=opBal.GetPatients();
            return View(model); 
        }


        public ActionResult OPID( int Id)
        {
           var model = opBal.OPID (Id);
            if(model == null)
            {
                return RedirectToAction("OutP", "Outpatient");
            }
            return View(model);
        }



    }
}