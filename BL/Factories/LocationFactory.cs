using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface ILocationFactory
    {
        LocationDTO Transform(Location l);
        Location Transform(LocationDTO dto);


    }
    public class LocationFactory : ILocationFactory
    {
        private readonly ILocationTypeFactory _locationTypeFactory;

        public LocationFactory(ILocationTypeFactory locationTypeFactory)
        {
            _locationTypeFactory = locationTypeFactory;
        }

        public LocationDTO Transform(Location l)
        {
            return new LocationDTO
            {
                LocationName = l.LocationName,
                Address = l.Address,
                LocationDescription = l.LocationDescription,
                LocationContact = l.LocationContact,
                LocationType = _locationTypeFactory.Transform(l.LocationType)
            };
        }

        public Location Transform(LocationDTO dto)
        {
            return new Location
            {
                LocationName = dto.LocationName,
                Address = dto.Address,
                LocationDescription = dto.LocationDescription,
                LocationContact = dto.LocationContact,
                LocationTypeId= dto.LocationTypeId             

            };
        }


    }


}
