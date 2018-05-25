using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.App.EF.Repositories
{
    public class EFPerformerRepository : EFRepository<Performer>, IPerformerRepository
    {
        public EFPerformerRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public override IEnumerable<Performer> All()
        {
            return RepositoryDbSet
                .Include(l => l.PerformerType)
                .ToList();
        }

        public async override Task<IEnumerable<Performer>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(p => p.PerformerType)
                .ToListAsync();
        }

        public override Performer Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(l => l.PerformerType)
                .SingleOrDefault(l => l.PerformerId == (int)id[0]);
        }

        public override Task<Performer> FindAsync(params object[] id)
        {
            return RepositoryDbSet
                .Include(p => p.PerformerType)
                .SingleOrDefaultAsync(l => l.PerformerId == (int)id[0]);
        }

        public IEnumerable<Performer> AllByTypeId(int id)
        {
            return RepositoryDbSet
                .Include(l => l.PerformerType)
                .Where(l => l.PerformerTypeId == id)
                .ToList();
        }

        public async Task<IEnumerable<Performer>> AllByTypeIdAsync(int id)
        {
            return await RepositoryDbSet
                .Include(l => l.PerformerType)
                .Where(l => l.PerformerTypeId == id)
                .ToListAsync();
        }
    }
    
}
