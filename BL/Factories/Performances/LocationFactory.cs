using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    /// <summary>
    /// Interface for LocationFactory
    /// </summary>
    public interface ILocationFactory
    {
        LocationDTO Transform(Location l);
        Location Transform(LocationDTO dto);


    }
    public class LocationFactory : ILocationFactory
    {
        private readonly ILocationTypeFactory _locationTypeFactory;

        /// <summary>
        /// This factory used to get information from locationTypeFactory for LocationFactory
        /// </summary>
        /// <param name="locationTypeFactory"></param>
        public LocationFactory(ILocationTypeFactory locationTypeFactory)
        {
            _locationTypeFactory = locationTypeFactory;
        }

        /// <summary>
        /// This method transforms LocationDTO to Location
        /// </summary>
        /// <param name="l"></param>
        /// <returns>LocationDTO of the Location</returns>
        ///        
        public LocationDTO Transform(Location l)
        {
            if (l == null) return null;
            return new LocationDTO
            {
                LocationName = l.LocationName,
                Address = l.Address,
                LocationDescription = l.LocationDescription,
                LocationContact = l.LocationContact,
                LocationType = _locationTypeFactory.Transform(l.LocationType)
            };
        }

        /// <summary>
        /// This method transforms Location to LocationDTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Location of the LocationDTO</returns>
        public Location Transform(LocationDTO dto)
        {
            if (dto == null) return null;
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
