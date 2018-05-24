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
            throw new NotImplementedException();
        }

        public LocationDTO GetLocationById(int id)
        {
            throw new NotImplementedException();
        }


    }
}
