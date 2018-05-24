
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public string InvoiceNr { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceSum { get; set; }
        public decimal InvoiceTax { get; set; }

        public List<InvoiceRowDTO> InvoiceRows { get; set; }
    }
}