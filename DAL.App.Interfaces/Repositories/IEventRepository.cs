using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.Interfaces.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> AllByTypeId(int id);
        Task<IEnumerable<Event>> AllByTypeIdAsync(int id);

    }
}
