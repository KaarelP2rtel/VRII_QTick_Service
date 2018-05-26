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
    class EFInvoiceRepository : EFRepository<Invoice>, IInvoiceRepository
    {
        public EFInvoiceRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public override IEnumerable<Invoice> All()
        {
            return RepositoryDbSet
                .Include(i => i.InvoiceRows)
                .ToList();
        }

        public IEnumerable<Invoice> AllForUser(string id)
        {
            return RepositoryDbSet
                .Include(i => i.InvoiceRows)
                .Where(i => i.ApplicationUserId==id)
                .ToList();
        }

        public override Invoice Find(params object[] id)
        {
            return RepositoryDbSet
                 .Include(i => i.InvoiceRows)
                 .SingleOrDefault(i => i.InvoiceId==(int)id[0]);
        }

      
    }
}
