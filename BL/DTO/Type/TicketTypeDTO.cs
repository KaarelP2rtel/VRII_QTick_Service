using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class TicketTypeDTO
    {
        public int TicketTypeId { get; set; }
        [MaxLength(100)]
        [Required]
        public string TicketTypeName{ get; set; }
        [Required]
        [MaxLength(1000)]
        public string TicketTypeDescription { get; set; }
    }
}
