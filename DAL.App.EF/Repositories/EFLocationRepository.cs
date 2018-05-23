using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Repositories
{
    public class EFLocationRepository : EFRepository<Location>, ILocationRepository
    {
        public EFLocationRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
