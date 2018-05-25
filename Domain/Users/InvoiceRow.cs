using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class InvoiceRow
    {
        //Entity properties
        public int InvoiceRowId { get; set; }
        public decimal Price { get; set; }
        public decimal RowTax { get; set; }

        //Table relations
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
