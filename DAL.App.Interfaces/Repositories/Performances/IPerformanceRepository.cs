﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces.Repositories
{
    public interface IPerformanceRepository : IRepository<Performance>
    {
        IEnumerable<Performance> AllWithPerformers();
        Performance FindWithPerformers(int id);
        IEnumerable<Performance> AllForEvent(int id);
    }
}
