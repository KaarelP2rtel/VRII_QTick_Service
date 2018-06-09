using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> EventType
    /// This should be used to transfer EventTypes between services.
    /// </summary>
    public class EventTypeDTO
    {
        public int EventTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string EventTypeName{ get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(10)]
        public string EventTypeDescription { get; set; }
    }
}
