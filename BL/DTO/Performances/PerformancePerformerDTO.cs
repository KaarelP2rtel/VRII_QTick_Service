using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> Performance's Performer
    /// This should be used to transfer PerformancePerformers between services.
    /// </summary>
    public class PerformancePerformerDTO
    {
        // This is a foreign key of Performance  
        [Required]
        public int PerformanceId { get; set; }

        // This is a foreign key of Performer
        [Required]
        public int PerformerId { get; set; }

    }
}
