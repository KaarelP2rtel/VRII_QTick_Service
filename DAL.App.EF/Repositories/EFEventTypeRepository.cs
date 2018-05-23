using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Repositories
{
    public class EFEventTypeRepository : EFRepository<EventType>, IEventTypeRepository
    {
        public EFEventTypeRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
