using Hospital_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_System.Models;
using Hospital_System.DAL;
using Hospital_System.Viewmodel;

namespace Hospital_System.Controllers
{
    public class ComplaintController : Controller
    {
        MenuBAL menuBAL = new MenuBAL();
        DoctorDAL doctorDAL;
        DoctorBAL doctorBAL = new DoctorBAL();


        // GET: Complaint


        //public ActionResult Registercomplaint()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult RegisterComplaint( MComplaint mComplaint)
        {
            var ids = 0;

            List<MComplaint> mComplaints = new List<MComplaint>();

            if(mComplaint ==null)
            {
                mComplaint = new MComplaint();

            }

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

                var model = new Allview
                {
                    Menus = menuBAL.GetMenus(),
                    mComplaint = mComplaint
                };




                return View(model);
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

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                mComplaints= mComplaint
            };
            return View(model);
        }


        public ActionResult CEdit(int Id)
        {
            if (Id <= 0)
                return HttpNotFound();


            MComplaint mComplaint = new MComplaint();
            mComplaint = doctorBAL.CEdit(Id);

            var model = new Allview
            {
                Menus = menuBAL.GetMenus(),
                mComplaint = mComplaint
            };
              

            if (mComplaint.Id != 0)
            {

                return View("RegisterComplaint", model);
            }
            else
            {
                return RedirectToAction("ComplaintList", model);


            }

          
          
        }
    }
}