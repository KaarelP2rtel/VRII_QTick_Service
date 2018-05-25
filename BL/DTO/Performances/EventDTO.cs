using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class EventDTO
    {
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
        [Required]
        public int EventTypeId { get; set; }
        public EventTypeDTO EventType { get; set; }
    }
}
