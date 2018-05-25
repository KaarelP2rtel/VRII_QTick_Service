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
    public class PerformerTypeService : IPerformerTypeService
    {

        private readonly IAppUnitOfWork _uow;
        private readonly IPerformerTypeFactory _performerTypeFactory;

        public PerformerTypeService(IAppUnitOfWork uow, IPerformerTypeFactory performerTypeFactory)
        {
            _uow = uow;
            _performerTypeFactory = performerTypeFactory;
        }

        public List<PerformerTypeDTO> GetAllPerformerTypes()
        {
            return _uow.PerformerTypes.All()
                .Select(pt => _performerTypeFactory.Transform(pt))
                .ToList();
        }

        public PerformerTypeDTO GetPerformerTypeById(int id)
        {
            return _performerTypeFactory.Transform(_uow.PerformerTypes.Find(id));
        }

        public PerformerTypeDTO AddNewPerformerType(PerformerTypeDTO newPerformerType)
        {
            //validation logic..
            var performerType = _performerTypeFactory.Transform(newPerformerType);
            _uow.PerformerTypes.Add(performerType);
            _uow.SaveChanges();
            return _performerTypeFactory.Transform(performerType);
        }
    }
}
