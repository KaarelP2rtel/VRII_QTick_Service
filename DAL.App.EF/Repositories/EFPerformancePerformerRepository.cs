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
    class EFPerformancePerformerRepository : EFRepository<PerformancePerformer>, IPerformancePerformerRepository
    {
        public EFPerformancePerformerRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public override IEnumerable<PerformancePerformer> All()
        {
            return RepositoryDbSet
                .Include(pp => pp.Performer)
                .Include(pp => pp.Performance)
                .ToList();
        }

        public override PerformancePerformer Find(params object[] id)
        {
            return RepositoryDbSet
                 .Include(pp => pp.Performer)
                 .Include(pp => pp.Performance)
                 .SingleOrDefault(pp => pp.PerformancePerformerId == (int)id[0]);
        }
    }
}
