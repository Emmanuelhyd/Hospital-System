using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_System.DAL;
using Hospital_System.Models;

namespace Hospital_System.BAL
{
   
    public class FeedbackAdBAL
    {
        FeedbackAdDAL feedbackDAL = new FeedbackAdDAL();

        //List
        public List<FeedbackDo> FeedbackListAdmin()
        {
            return feedbackDAL.FeedbackListAdmin();
        }


        //Add feedback 

        public List<FeedbackDo> AddFeedbackAd(FeedbackDo feedbackDo)
        {
            List<FeedbackDo> feedbackDos = new List<FeedbackDo>();
            feedbackDos = feedbackDAL.AddFeedbackAd(feedbackDo);
            return feedbackDos;
        }

        //Attendance edit
        public FeedbackDo FeedbackEdit(int Id)
        {
            FeedbackDo feedbackDos = feedbackDAL.FeedbackEdit(Id);

            return feedbackDos;
        }
        //Attendance delete
        public List<FeedbackDo> FeedbackDelete(int Id)
        {
            List<FeedbackDo> feedbackDos = feedbackDAL.FeedbackDelete(Id);
            return feedbackDos;
        }
    }
}