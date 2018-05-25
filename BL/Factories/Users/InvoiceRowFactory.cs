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
            if (ir == null) return null;
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
            if (dto == null) return null;
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
