using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Ticket
    {
        //Entity properties
        public int TicketId { get; set; }
        [MaxLength(100)]
        public string TicketNr { get; set; }
        public DateTime DatePurchased { get; set; }

        //Table relations
        public int PerformanceId { get; set; }
        public Performance Performance { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
}
}
