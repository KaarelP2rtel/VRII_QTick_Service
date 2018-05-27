using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class LocationTypeService : ILocationTypeService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILocationTypeFactory _locationTypeFactory;

        public LocationTypeService(IAppUnitOfWork uow, ILocationTypeFactory locationTypeFactory)
        {
            _uow = uow;
            _locationTypeFactory = locationTypeFactory;
        }

        public LocationTypeDTO AddNewLocationType(LocationTypeDTO newLocationType)
        {
            try
            {
                var lt = _locationTypeFactory.Transform(newLocationType);
                _uow.LocationTypes.Add(lt);
                _uow.SaveChanges();
                return _locationTypeFactory.Transform(lt);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }

        public bool DeleteLocationType(int id)
        {
            try
            {
                _uow.LocationTypes.Remove(id);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }

        }

        public List<LocationTypeDTO> GetAllLocationTypes()
        {
            return _uow.LocationTypes
                .All()
                .Select(lt => _locationTypeFactory.Transform(lt))
                .ToList();

        }

        public LocationTypeDTO GetLocationTypeById(int id)
        {
            return _locationTypeFactory.Transform(_uow.LocationTypes.Find(id));
        }

        public LocationTypeDTO UpdateLocationType(LocationTypeDTO locationType)
        {
            try
            {
                var lt = _uow.LocationTypes.Update(_locationTypeFactory.Transform(locationType));
                _uow.SaveChanges();
                return _locationTypeFactory.Transform(lt);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }
    }
}
