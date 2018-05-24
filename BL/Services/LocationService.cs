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

        public async Task<LocationDTO> AddNewLocation(LocationDTO newLocation)
        {
            var l = _locationFactory.Transform(newLocation);
            await _uow.Locations.AddAsync(l);
            return _locationFactory.Transform(await _uow.Locations.FindAsync(l.LocationId));
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
               .All()
               .Select(l => _locationFactory.Transform(l))
               .ToList();
        }

        public LocationDTO GetLocationById(int id)
        {
            throw new NotImplementedException();
        }


    }
}
