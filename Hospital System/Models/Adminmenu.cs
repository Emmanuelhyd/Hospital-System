﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class Adminmenu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int? ParentId { get; set; }

        public byte Isactive { get; set; }




    }
}