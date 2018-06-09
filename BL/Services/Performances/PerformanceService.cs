using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
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
            try
            {
                var p = _performanceFactory.Transform(newPerformance);
                _uow.Performances.Add(p);
                _uow.SaveChanges();
                var added = _uow.Performances.Find(p.PerformanceId);
                return _performanceFactory.Transform(added);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }


        }


        public PerformanceDTO AddPerformerToPerformance(PerformancePerformerDTO dto)
        {
#warning should create factory


            try
            {
                _uow.PerformancePerformers
                               .Add(new PerformancePerformer
                               {
                                   PerformerId = dto.PerformerId,
                                   PerformanceId = dto.PerformanceId
                               });
                _uow.SaveChanges();
                return _performanceFactory.TransformWithPerformers(_uow.Performances.FindWithPerformers(dto.PerformanceId));
            }
            catch (DBConcurrencyException)
            {
                return null;
            }
        }

        public bool DeletePerformance(int id)
        {

            try
            {
                _uow.Performances.Remove(id);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }
        }

        public PerformanceDTO GetPerformanceById(int id)
        {
            return _performanceFactory.Transform(_uow.Performances.Find(id));
        }

        public PerformanceDTO GetPerformanceByIdWithPerformer(int id)
        {
            return _performanceFactory.TransformWithPerformers(_uow.Performances.Find(id));
        }

        public List<PerformanceDTO> GetPerformances()
        {
            return _uow.Performances.All().Select(p => _performanceFactory.Transform(p)).ToList();
        }

        public List<PerformanceDTO> GetPerformancesForEvent(int id)
        {
            return _uow.Performances.AllForEvent(id).Select(p => _performanceFactory.Transform(p)).ToList();
        }

        public List<PerformanceDTO> GetPerformancesWithPerformers()
        {
            return _uow.Performances.AllWithPerformers().Select(p => _performanceFactory.TransformWithPerformers(p)).ToList();
        }

        public bool RemovePerformerFromPerformance(int performanceId, int performerId)
        {
            try
            {
                var pp = _uow.PerformancePerformers.FindByBothIds(performanceId, performerId);
                _uow.PerformancePerformers.Remove(pp);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }

        }

        public PerformanceDTO UpdatePerformance(PerformanceDTO performance)
        {

            try
            {
                var p = _uow.Performances.Update(_performanceFactory.Transform(performance));
                _uow.SaveChanges();
                return _performanceFactory.TransformWithPerformers(p);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }
        }
    }
}
