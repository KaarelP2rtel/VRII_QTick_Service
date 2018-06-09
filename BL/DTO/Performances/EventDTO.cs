using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> Event
    /// This should be used to transfer Events between services.
    /// </summary>
    public class EventDTO
    {
        public int EventId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string EventName { get; set; }

        [Required]
        [MaxLength(1000)]
        [MinLength(20)]
        public string EventDescription { get; set; }

        [MaxLength(500)]
        public string ImageLink { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string EventDuration { get; set; }
        [MaxLength(100)]
        public string EventPage { get; set; }

        // This is a foreign key of Event Type
        [Required]
        public int EventTypeId { get; set; }
        public EventTypeDTO EventType { get; set; }
    }
}
