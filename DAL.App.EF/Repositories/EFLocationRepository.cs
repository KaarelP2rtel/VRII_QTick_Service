using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return base.All();
        }

        public override Task<IEnumerable<Location>> AllAsync()
        {
            return base.AllAsync();
        }

        public IEnumerable<Location> AllByTypeId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task<Location>> AllByTypeIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public override Location Find(params object[] id)
        {
            return base.Find(id);
        }

        public override Task<Location> FindAsync(params object[] id)
        {
            return base.FindAsync(id);
        }
    }
}
