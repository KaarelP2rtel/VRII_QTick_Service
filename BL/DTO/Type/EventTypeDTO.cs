using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class EventTypeDTO
    {
        public int EventTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string EventTypeName{ get; set; }
        [Required]
        [MaxLength(1000)]
        public string EventTypeDescription { get; set; }
    }
}
