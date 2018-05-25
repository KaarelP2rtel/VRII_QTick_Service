using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class InvoiceRowDTO
    {
        public int InvoiceRowId { get; set; }
        public decimal Price { get; set; }
        public decimal RowTax { get; set; }
        public int TicketId { get; set; }

    }
}
