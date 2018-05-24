﻿using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.Interfaces.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        IEnumerable<Location> AllByTypeId(int id);
        Task<IEnumerable<Location>> AllByTypeIdAsync(int id);
    }
}
