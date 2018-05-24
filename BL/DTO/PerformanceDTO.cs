using System;
using System.Collections.Generic;

namespace BL.DTO
{
    public class PerformanceDTO
    {
        public int PerformanceId { get; set; }
        public string TicketInfo { get; set; }
        public string PerformanceDescription { get; set; }
        public DateTime PerformanceTime { get; set; }
        public int LocationId { get; set; }
        public LocationDTO Location { get; set; }
        public int EventId { get; set; }
        public EventDTO Event { get; set; }
        public List<PerformerDTO> Performers { get; set; }

    }
}
