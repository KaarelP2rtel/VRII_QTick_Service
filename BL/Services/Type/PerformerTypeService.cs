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
            try
            {
                var performerType = _performerTypeFactory.Transform(newPerformerType);
                _uow.PerformerTypes.Add(performerType);
                _uow.SaveChanges();
                return _performerTypeFactory.Transform(performerType);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }

        public bool DeletePerformerType(int id)
        {
            try
            {
                _uow.PerformerTypes.Remove(id);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }

        }

        public PerformerTypeDTO UpdatePerformerType(PerformerTypeDTO performerType)
        {

            try
            {
                var p = _uow.PerformerTypes.Update(_performerTypeFactory.Transform(performerType));
                _uow.SaveChanges();
                return _performerTypeFactory.Transform(p);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }
        }
    }
}
