using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Factories
{
    public interface IInvoiceFactory
    {
        InvoiceDTO Transform(Invoice i);
        Invoice Transform(InvoiceDTO dto);
    }
    public class InvoiceFactory : IInvoiceFactory
    {
        private readonly IInvoiceRowFactory _invoiceRowFactory;

        public InvoiceFactory(IInvoiceRowFactory invoiceRowFactory)
        {
            _invoiceRowFactory = invoiceRowFactory;
        }

        public InvoiceDTO Transform(Invoice i)
        {
            if (i == null) return null;
            return new InvoiceDTO
            {

                InvoiceNr = i.InvoiceNr,
                InvoiceDate = i.InvoiceDate,
                InvoiceSum = i.InvoiceSum,
                InvoiceTax = i.InvoiceTax,
                InvoiceRows = i.InvoiceRows.Select(j => _invoiceRowFactory.Transform(j)).ToList()
            };
        }
 
        public Invoice Transform(InvoiceDTO dto)
        {
            if (dto == null) return null;
            return new Invoice
            {
                InvoiceNr = dto.InvoiceNr,
                InvoiceDate = dto.InvoiceDate,
                InvoiceSum = dto.InvoiceSum,
                InvoiceTax = dto.InvoiceTax
            };
        }
    }
    
}
