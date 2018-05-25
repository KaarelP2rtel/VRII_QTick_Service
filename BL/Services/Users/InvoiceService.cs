using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;

namespace BL.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IInvoiceFactory _invoiceFactory;

        public InvoiceService(IAppUnitOfWork uow, IInvoiceFactory invoiceFactory)
        {
            _uow = uow;
            _invoiceFactory = invoiceFactory;
        }

        public List<InvoiceDTO> GetAllInvoices()
        {
            return _uow.Invoices
                .All()
                .Select(i => _invoiceFactory.Transform(i))
                .ToList();
        }

        public InvoiceDTO GetInvoiceById(int id)
        {
            return _invoiceFactory.Transform(_uow.Invoices.Find(id));
        }

        public InvoiceDTO AddNewInvoice(InvoiceDTO newInvoice)
        {
            var l = _invoiceFactory.Transform(newInvoice);
            _uow.Invoices.Add(l);
            _uow.SaveChanges();
            return _invoiceFactory.Transform(_uow.Invoices.Find(l.InvoiceId));
        }
    }
}
