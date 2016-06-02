using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCorridorSystem.Models
{
    public class ScheduleViewModal
    {
        public List<Events> Schedule { get; set; }

        public ScheduleViewModal()
        {
            Schedule = new List<Events>();
        }
    }
}