using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    class EFPerformancePerformerRepository : EFRepository<PerformancePerformer>, IPerformancePerformerRepository
    {
        public EFPerformancePerformerRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
