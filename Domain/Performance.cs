using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Performance
    {
        //Performance properties
        public int PerformanceId { get; set; }
        [MaxLength(1000)]
        public string TicketInfo { get; set; }
        [MaxLength(1000)]
        public string PerformanceDescription { get; set; }
        public DateTime PerformanceTime { get; set; }

        //Table relations
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public List<PerformancePerformer> PerformancePerformers { get; set; }
    }
}