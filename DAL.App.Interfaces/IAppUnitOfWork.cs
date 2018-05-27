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

        IEventRepository Events { get; }
        IRepository<EventType> EventTypes { get; }
        IInvoiceRepository Invoices { get; }
        IRepository<InvoiceRow> InvoiceRows { get; }
        ILocationRepository Locations { get; }
        IRepository<LocationType> LocationTypes { get; }
        IPerformancePerformerRepository PerformancePerformers { get; }
        IPerformanceRepository Performances { get; }
        IPerformerRepository Performers { get; }
        IRepository<PerformerType> PerformerTypes { get; }
        ITicketRepository Tickets { get; }
        IRepository<TicketType> TicketTypes { get; }

        IUserRepository Users { get; }
    }
}
