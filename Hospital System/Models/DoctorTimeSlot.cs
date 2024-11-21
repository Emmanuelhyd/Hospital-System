using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_System.Models
{
    public class DoctorTimeSlot
    {

        public int TimeSlotId { get; set; }

        public int DoctorId { get; set; }

        [DataType(DataType.DateTime)]

        public DateTime SlotDate { get; set; }
        public TimeSpan Slot1 { get; set; }
        public TimeSpan Slot2 { get; set; }
        public TimeSpan Slot3 { get; set; }
        public TimeSpan Slot4 { get; set; }
        public TimeSpan Slot5 { get; set; }

        public bool IsAvailable { get; set; }


        public Doctor Doctor { get; set; }
    }
}