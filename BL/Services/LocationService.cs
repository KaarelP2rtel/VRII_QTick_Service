using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ILocationFactory _locationFactory;

        public LocationService(IAppUnitOfWork uow, ILocationFactory locationFactory)
        {
            _uow = uow;
            _locationFactory = locationFactory;
        }

        public LocationDTO AddNewLocation(LocationDTO newLocation)
        {
            var l = _locationFactory.Transform(newLocation);
             _uow.Locations.Add(l);
            _uow.SaveChanges();
            return _locationFactory.Transform( _uow.Locations.Find(l.LocationId));
            //return newLocation;
        }

        public List<LocationDTO> GetAllLocations()
        {
            return _uow.Locations
                .All()
                .Select(l => _locationFactory.Transform(l))
                .ToList();
        }

        public List<LocationDTO> GetAllLocationsByTypeId(int typeId)
        {
            return _uow.Locations
               .AllByTypeId(typeId)
               .Select(l => _locationFactory.Transform(l))
               .ToList();
        }

        public LocationDTO GetLocationById(int id)
        {
            return _locationFactory.Transform(_uow.Locations.Find(id));       
        }


    }
}
