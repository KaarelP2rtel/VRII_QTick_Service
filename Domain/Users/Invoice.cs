using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Invoice
    {
        //Entity properties
        public int InvoiceId { get; set; }
        [MaxLength(100)]
        public string InvoiceNr { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceSum { get; set; }
        public decimal InvoiceTax { get; set; }

        //Table relations
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<InvoiceRow> InvoiceRows { get; set; }
    }
}
