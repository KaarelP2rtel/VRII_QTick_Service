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

        public List<PerformerDTO> GetAllPerformers()
        {
            return _uow.Performers.All()
                .Select(p => _performerFactory
                .Transform(p))
                .ToList();
        }

        public PerformerDTO GetPerformerByTypeId(int typeId)
        {
            throw new NotImplementedException();
        }

        public PerformerDTO GetPerformerById(int personId)
        {
            throw new NotImplementedException();
        }

        public PerformerDTO AddNewPerformer(PerformerDTO newPerformer)
        {
            throw new NotImplementedException();
        }
    }
}
