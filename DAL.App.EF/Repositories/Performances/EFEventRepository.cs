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
    public class EFEventRepository : EFRepository<Event>, IEventRepository
    {
        public EFEventRepository(DbContext dataContext) : base(dataContext)
        {

        }

        public override IEnumerable<Event> All()
        {
            return RepositoryDbSet
                .Include(e => e.EventType)
                .ToList();

        }

        public async override Task<IEnumerable<Event>> AllAsync()
        {
            return await RepositoryDbSet
                 .Include(e => e.EventType)
                 .ToListAsync();
        }

        public IEnumerable<Event> AllByTypeId(int id)
        {
            return RepositoryDbSet
                .Include(e => e.EventType)
                .Where(e => e.EventTypeId == id)
                .ToList();
        }

        public async Task<IEnumerable<Event>> AllByTypeIdAsync(int id)
        {
            return await RepositoryDbSet
               .Include(e => e.EventType)
               .Where(e => e.EventTypeId == id)
               .ToListAsync();
        }

        public override Event Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(e => e.EventType)
                .SingleOrDefault(e => e.EventId == (int)id[0]);
        }

        public override Task<Event> FindAsync(params object[] id)
        {
            return RepositoryDbSet
                .Include(e => e.EventType)
                .SingleOrDefaultAsync(e => e.EventId == (int)id[0]);

        }
    }
}
