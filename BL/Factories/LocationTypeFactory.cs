using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface ILocationTypeFactory
    {
        LocationTypeDTO Transform(LocationType lt);
        LocationType Transform(LocationTypeDTO dto);
    }
    public class LocationTypeFactory : ILocationTypeFactory
    {
        public LocationTypeDTO Transform(LocationType lt)
        {
            return new LocationTypeDTO
            {
                LocationTypeId = lt.LocationTypeId,
                LocationTypeName = lt.Name,
                LocationTypeDescription = lt.Description

            };
        }

        public LocationType Transform(LocationTypeDTO dto)
        {
            return new LocationType
            {
                LocationTypeId = dto.LocationTypeId,
                Name = dto.LocationTypeName,
                Description = dto.LocationTypeDescription

            };
        }
    }


}
