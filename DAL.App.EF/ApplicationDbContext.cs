using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    /// <summary>
    /// Here are detailed all of the domains that will be included in the database. 
    /// If you want to add something to database then this is the place to start. 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDataContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Event> Events { get; set; }
        public DbSet<Domain.EventType> EventTypes { get; set; }
        public DbSet<Domain.Invoice> Invoices { get; set; }
        public DbSet<Domain.InvoiceRow> InvoiceRows { get; set; }
        public DbSet<Domain.Location> Locations { get; set; }
        public DbSet<Domain.LocationType> LocationTypes { get; set; }
        public DbSet<Domain.Performance> Performances { get; set; }
        public DbSet<Domain.Performer> Performers { get; set; }
        public DbSet<Domain.PerformancePerformer> PerformancePerformers { get; set; }
        public DbSet<Domain.PerformerType> PerformerTypes { get; set; }
        public DbSet<Domain.Ticket> Tickets { get; set; }
        public DbSet<Domain.TicketType> TicketTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
