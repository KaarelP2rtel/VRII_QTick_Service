using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;

namespace BL.Interfaces
{
    public interface IInvoiceService
    {
        List<InvoiceDTO> GetAllInvoices();

        InvoiceDTO GetInvoiceById(int id);
        InvoiceDTO AddNewInvoice(InvoiceDTO newInvoice);
    }
}
