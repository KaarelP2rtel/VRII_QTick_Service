using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    class EFPerformerRepository : EFRepository<Performer>, IPerformerRepository
    {
        public EFPerformerRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
