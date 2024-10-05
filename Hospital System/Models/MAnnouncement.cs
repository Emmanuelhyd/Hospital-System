using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class MAnnouncement
    {

        //[Required(ErrorMessage = "Id is required.")]
        //public int Id { get; set; }

        //[Required(ErrorMessage = "Announcement is required.")]
        //[StringLength(500, ErrorMessage = "Announcement cannot be longer than 500 characters.")]
        //public string Announcement { get; set; }

        //[Required(ErrorMessage = "AnnouncementFor is required.")]
        //public string AnnouncementFor { get; set; }

        //[Required(ErrorMessage = "EndDate is required.")]
        //[DataType(DataType.Date)]
        //public string EndDate { get; set; }


        public int Id { get; set; }
        public string Announcement { get; set; }
        public string AnnouncementFor { get; set; }
        public string EndDate { get; set; }
    }
}