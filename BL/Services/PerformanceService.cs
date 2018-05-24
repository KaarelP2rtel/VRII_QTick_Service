using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IPerformanceFactory _performanceFactory;

        public PerformanceService(IAppUnitOfWork uow, IPerformanceFactory performanceFactory)
        {
            _uow = uow;
            _performanceFactory = performanceFactory;
        }

        public PerformanceDTO AddNewPerformance(PerformanceDTO newPerformance)
        {
            var p = _performanceFactory.Transform(newPerformance);
            _uow.Performances.Add(p);
            var added = _uow.Performances.Find(p.PerformanceId);
            if (added == null) return null;
            return _performanceFactory.Transform(added);

        }

        public PerformanceDTO GetPerformanceById(int id)
        {
            return _performanceFactory.Transform(_uow.Performances.Find(id));
        }

        public List<PerformanceDTO> GetPerformances()
        {
            return _uow.Performances.All().Select(p => _performanceFactory.Transform(p)).ToList();
        }

        public List<PerformanceDTO> GetPerformancesWithPerformers()
        {
            return _uow.Performances.All().Select(p => _performanceFactory.TransformWithPerformers(p)).ToList();
        }
    }
}
