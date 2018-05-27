using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces.Repositories
{
    public interface IPerformancePerformerRepository : IRepository<PerformancePerformer>
    {
        PerformancePerformer FindByBothIds(int performanceId, int performerId);
    }
}
