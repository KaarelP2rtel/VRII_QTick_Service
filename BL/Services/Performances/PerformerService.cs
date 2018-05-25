using System;
using System.Collections.Generic;
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
            var p = _performerFactory.Transform(newPerformer);
            _uow.Performers.Add(p);
            _uow.SaveChanges();
            return _performerFactory.Transform(_uow.Performers.Find(p.PerformerId));
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


    }
}
