using Domain.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Event
    {
        //Event properties
        public int EventId { get; set; }
        [MaxLength(100)]
        public string EventName { get; set; }
        [MaxLength(1000)]
        public string EventDescription { get; set; }
        [MaxLength(500)]
        public string ImageLink { get; set; }
        [MaxLength(200)]
        public string EventDuration { get; set; }
        [MaxLength(100)]
        public string EventPage { get; set; }
        //Table Relations
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }

        public List<Performance> Performances { get; set; }
    }
}
