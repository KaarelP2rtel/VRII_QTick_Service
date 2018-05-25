using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces.Repositories
{
    public interface IPerformerRepository : IRepository<Performer>
    {
        IEnumerable<Performer> AllByTypeId(int id);
        Task<IEnumerable<Performer>> AllByTypeIdAsync(int id);
    }
}
