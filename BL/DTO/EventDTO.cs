using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class EventDTO
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public string ImageLink { get; set; }

        public string EventDuration { get; set; }

        public string EventPage { get; set; }

        public int EventTypeId { get; set; }
        public EventTypeDTO EventType { get; set; }
    }
}
