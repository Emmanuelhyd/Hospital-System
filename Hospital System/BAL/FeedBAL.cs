using Hospital_System.DAL;
using Hospital_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.BAL
{
    public class FeedBAL
    {
        FeedDAL feedDAL = new FeedDAL();

        public string Feed(Feedbk feedbk)
        {
            return feedDAL.Feed(feedbk);

        }
    }
}