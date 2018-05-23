using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Repositories
{
    public class EFPerformanceRepository : EFRepository<Performance>, IPerformanceRepository
    {
        public EFPerformanceRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
