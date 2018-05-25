using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class TicketDTO
    {


        public int TicketId { get; set; }
        [MaxLength(100)]
        [Required]
        public string TicketNr { get; set; }
        [Required]
        public DateTime DatePurchased { get; set; }

        [Required]
        public int PerformanceId { get; set; }
        public PerformanceDTO Performance { get; set; }
        [Required]
        [MaxLength(100)]
        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }
        [Required]
        public int TicketTypeId { get; set; }
        public TicketTypeDTO TicketType { get; set; }
    }
}
