using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class TicketDTO
    {


        public int TicketId { get; set; }
        public string TicketNr { get; set; }
        public DateTime DatePurchased { get; set; }

        public int PerformanceId { get; set; }
        public PerformanceDTO Performance { get; set; }
        //public int ApplicationUserId { get; set; }
        //public ApplicationUserDTO ApplicationUser { get; set; }
        public int TicketTypeId { get; set; }
        public TicketTypeDTO TicketType { get; set; }
    }
}
