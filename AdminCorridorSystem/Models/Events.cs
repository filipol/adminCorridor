using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCorridorSystem.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string DTEnd { get; set; }
        public string DTStart { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DTStamp { get; set; }
        public DateTime LastModified { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public string externalId { get; set; }
    }
}