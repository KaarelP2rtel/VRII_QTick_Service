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
    public class EFLocationRepository : EFRepository<Location>, ILocationRepository
    {
        public EFLocationRepository(DbContext dataContext) : base(dataContext)
        {

        }

        public override IEnumerable<Location> All()
        {
            return RepositoryDbSet
                .Include(l => l.LocationType)
                .ToList();

        }

        public async override Task<IEnumerable<Location>> AllAsync()
        {
            return await RepositoryDbSet
                 .Include(l => l.LocationType)
                 .ToListAsync();
        }

        public IEnumerable<Location> AllByTypeId(int id)
        {
            return RepositoryDbSet
                .Include(l => l.LocationType)
                .Where(l => l.LocationTypeId==id)
                .ToList();
        }

        public async Task<IEnumerable<Location>> AllByTypeIdAsync(int id)
        {
            return await RepositoryDbSet
               .Include(l => l.LocationType)
               .Where(l => l.LocationTypeId == id)
               .ToListAsync();
        }

        public override Location Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(l => l.LocationType)
                .SingleOrDefault(l => l.LocationId == (int)id[0]);
        }

        public override Task<Location> FindAsync(params object[] id)
        {
            return RepositoryDbSet
                .Include(l => l.LocationType)
                .SingleOrDefaultAsync(l => l.LocationId == (int)id[0]);

        }
    }
}
