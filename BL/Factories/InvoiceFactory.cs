using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface IInvoiceFactory
    {
        InvoiceDTO Transform(Invoice i);
        Invoice Transform(InvoiceDTO i);
    }
    public class InvoiceFactory : IInvoiceFactory
    {
    }

   
}
