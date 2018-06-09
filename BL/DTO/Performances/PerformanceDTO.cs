using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> Performance
    /// This should be used to transfer Performances between services.
    /// </summary>
    public class PerformanceDTO
    {
        public int PerformanceId { get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(5)]
        public string TicketInfo { get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(10)]
        public string PerformanceDescription { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(10)]
        public DateTime PerformanceTime { get; set; }

        // This is a foreign key of Performance Location 
        [Required]
        public int LocationId { get; set; }
        public LocationDTO Location { get; set; }

        // This is a foreign key of Performance Event 
        [Required]
        public int EventId { get; set; }
        public EventDTO Event { get; set; }
        public List<PerformerDTO> Performers { get; set; }

    }
}
