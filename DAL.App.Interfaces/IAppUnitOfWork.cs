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
        /// <summary>
        /// This is the interface which we will always use later to add things to the database
        /// If we want to add something to database then it must be here also. 
        /// </summary>
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
