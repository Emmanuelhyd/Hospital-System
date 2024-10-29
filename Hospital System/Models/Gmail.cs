using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class Gmail
    {

        public string To { get; set; }

        public string From { get; set; }

        public string Subject {  get; set; }

        public string Body { get; set; }

        public int  PatientId { get; set;}

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}