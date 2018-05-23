using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        //IPersonRepository People { get; }

        //IRepository<Contact> Contacts { get; }
        IRepository<Event> Events { get; }
        IRepository<EventType> EventTypes { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<InvoiceRow> InvoiceRows { get; }
        IRepository<Location> Locations { get; }
        IRepository<LocationType> LocationTypes { get; }
        IRepository<PerformancePerformer> PerformancePerformers { get; }
        IRepository<Performance> Performances { get; }
        IRepository<Performer> Performers { get; }
        IRepository<PerformerType> PerformerTypes { get; }
        IRepository<Ticket> Tickets { get; }
        IRepository<TicketType> TicketTypes { get; }
    }
}
