﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class EFTicketRepository : EFRepository<Ticket>, ITicketRepository
    {
        public EFTicketRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public override IEnumerable<Ticket> All()
        {
            return RepositoryDbSet
                
                .Include(t => t.Performance)
                .Include(t => t.TicketType)
                
                .ToList();
        }

        public List<Ticket> AllForUser(string id)
        {
            return RepositoryDbSet
                .Where(t => t.ApplicationUserId == id)
                .ToList();
        }

        public override Ticket Find(params object[] id)
        {
            return RepositoryDbSet
                
                .Include(t => t.Performance)
                .Include(t => t.TicketType)
                
                .SingleOrDefault(t => t.TicketId==(int)id[0]);
        }

        public Ticket FindForUser(string id, int ticketId)
        {
            return RepositoryDbSet
                .Where(t => t.ApplicationUserId == id && t.TicketId == ticketId)
                .SingleOrDefault();

        }

        public Ticket FindWithUser(int id)
        {
            return RepositoryDbSet
                .Include(t => t.ApplicationUser)
                .SingleOrDefault(t => t.TicketId==id);
        }
    }
}
