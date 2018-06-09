using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> TicketType
    /// This should be used to transfer TicketTypes between services.
    /// </summary>
    public class TicketTypeDTO
    {
        public int TicketTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string TicketTypeName{ get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(10)]
        public string TicketTypeDescription { get; set; }
    }
}
