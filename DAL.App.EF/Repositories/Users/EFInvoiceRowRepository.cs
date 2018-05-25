using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    class EFInvoiceRowRepository : EFRepository<InvoiceRow>, IInvoiceRowRepository
    {
        public EFInvoiceRowRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public override IEnumerable<InvoiceRow> All()
        {
            return RepositoryDbSet
                .Include(ir => ir.Ticket)
                .ToList();
        }


        public override InvoiceRow Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(ir => ir.Ticket)
                .SingleOrDefault(ir => ir.TicketId == (int)id[0]);
        }
    }
}
