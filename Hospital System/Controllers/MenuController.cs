using Hospital_System.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital_System.Controllers
{
    public class MenuController : Controller
    {
        MenuBAL menuBAL = new MenuBAL();
        // GET: Menu
        public ActionResult Menu()
        {
            var menu = menuBAL.GetMenus();
            return View(menu);
        }

    }
}