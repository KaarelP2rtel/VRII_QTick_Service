using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.EF.Repositories
{
    public class EFPerformanceRepository : EFRepository<Performance>, IPerformanceRepository
    {
        public EFPerformanceRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public override IEnumerable<Performance> All()
        {
            return RepositoryDbSet
                .Include(p => p.Event)
                .Include(p => p.Location)
                .ToList();
        }

        public IEnumerable<Performance> AllForEvent(int id)
        {
            return RepositoryDbSet
                .Include(p => p.Event)
                .Include(p => p.Location)
                .Include(p => p.PerformancePerformers)
                    .ThenInclude(pp => pp.Performer)
                .Where(p => p.EventId==id)
                .ToList();
        }

        public IEnumerable<Performance> AllWithPerformers()
        {
            return RepositoryDbSet
                .Include(p => p.Event)
                .Include(p => p.Location)
                .Include(p => p.PerformancePerformers)
                    .ThenInclude(pp => pp.Performer)
                .ToList();
        }

        public override Performance Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(p => p.Event)
                .Include(p => p.Location)
                .SingleOrDefault(p => p.PerformanceId == (int)id[0]);
        }

      

        public Performance FindWithPerformers(int id)
        {
            return RepositoryDbSet
                .Include(p => p.Event)
                .Include(p => p.Location)
                .Include(p => p.PerformancePerformers)
                    .ThenInclude(pp => pp.Performer)
                .SingleOrDefault(p => p.PerformanceId == id);
        }
    }
}
