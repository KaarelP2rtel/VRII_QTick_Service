using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;

namespace BL.Services
{
    public class PerformerService : IPerformerService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IPerformerFactory _performerFactory;

        public PerformerService(IAppUnitOfWork uow, IPerformerFactory performerFactory)
        {
            _uow = uow;
            _performerFactory = performerFactory;
        }

        public PerformerDTO AddNewPerformer(PerformerDTO newPerformer)
        {
            try
            {
                var p = _performerFactory.Transform(newPerformer);
                _uow.Performers.Add(p);
                _uow.SaveChanges();
                return _performerFactory.Transform(_uow.Performers.Find(p.PerformerId));
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }

        public bool DeletePerformer(int id)
        {
            try
            {
                _uow.Performers.Remove(id);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }

        }

        public List<PerformerDTO> GetAllPerformers()
        {
            return _uow.Performers
                .All()
                .Select(p => _performerFactory.Transform(p))
                .ToList();
        }

        public List<PerformerDTO> GetAllPerformersByTypeId(int typeId)
        {
            return _uow.Performers
                .AllByTypeId(typeId)
                .Select(p => _performerFactory.Transform(p))
                .ToList();
        }

        public PerformerDTO GetPerformerById(int id)
        {
            return _performerFactory.Transform(_uow.Performers.Find(id));
        }

        public PerformerDTO UpdatePerformer(PerformerDTO performer)
        {
            try
            {
                var p = _uow.Performers.Update(_performerFactory.Transform(performer));
                _uow.SaveChanges();
                return _performerFactory.Transform(p);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }
    }
}
