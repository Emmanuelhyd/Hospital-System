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


        //List
        public List<Feedbk> FeedList()
        {
            return feedDAL.FeedList();
        }


        public List<Feedbk> Feed(Feedbk feedbk)
        {
            List<Feedbk> feedbks = new List<Feedbk>();
            feedbks = feedDAL.Feed(feedbk);
            return feedbks;
        }
    }
}