using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class MenuBAL
    {
        MenuDAL menuDAL = new MenuDAL();

        public List< Menu> GetMenus()
        {
            return menuDAL.GetMenus();
        }
    }
}