using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface IInvoiceRowFactory
    {
        InvoiceRowDTO Transform(InvoiceRow ir);
        InvoiceRow Transform(InvoiceRowDTO dto);
    }
    public class InvoiceRowFactory : IInvoiceRowFactory
    {
        public InvoiceRowDTO Transform(InvoiceRow ir)
        {
            return new InvoiceRowDTO
            {
                InvoiceRowId = ir.InvoiceRowId,
                Price = ir.Price,
                RowTax = ir.RowTax,
                TicketId=ir.TicketId
                
            };
        }

        public InvoiceRow Transform(InvoiceRowDTO dto)
        {
            return new InvoiceRow
            {
                InvoiceRowId = dto.InvoiceRowId,
                Price = dto.Price,
                RowTax = dto.RowTax,
                TicketId=dto.TicketId
            };
        }
    }


}
