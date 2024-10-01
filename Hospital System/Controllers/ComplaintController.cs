using Hospital_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;
using Hospital_System.DAL;

namespace Hospital_System.Controllers
{
    public class ComplaintController : Controller
    {
        DoctorDAL doctorDAL;
        DoctorBAL doctorBAL = new DoctorBAL();


        // GET: Complaint


        //public ActionResult Registercomplaint()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult RegisterComplaint(MComplaint mComplaint)
        {
            var ids = 0;

            List<MComplaint> mComplaints = new List<MComplaint>();

            if (mComplaint.Id != 0)
            {
                mComplaints = doctorBAL.RegisterComplaint(mComplaint);
            }

            if (mComplaints.Count == 0)
            {
                doctorDAL = new DoctorDAL();

               if (mComplaint.Id==0)
                {
                  ids=  doctorDAL.dynamicint();
                }
                mComplaint.Id = ids + 1;

                return View(mComplaint);
            }

            else
            {
                return RedirectToAction("ComplaintList", mComplaints);
            }

        }

        public ActionResult ComplaintList()
        {
            MComplaint mComplaint1 = new MComplaint();

            List<MComplaint> mComplaint = new List<MComplaint>();

            mComplaint = doctorBAL.ComplaintList();
            return View(mComplaint);
        }


        public ActionResult CEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();


            MComplaint mComplaint = new MComplaint();
            mComplaint = doctorBAL.CEdit(Id);
            if (mComplaint.Id != 0)
            {

                return View("RegisterComplaint", mComplaint);
            }
            else
            {
                return RedirectToAction("ComplaintList", "Complaint");


            }
        }
    }
}