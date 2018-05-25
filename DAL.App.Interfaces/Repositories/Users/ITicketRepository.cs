using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Ticket FindWithUser(int id);
    }
}
