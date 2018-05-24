using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface ILocationService
    {
        List<LocationDTO> GetAllLocations();
        List<LocationDTO> GetAllLocationsByTypeId(int typeId);

        LocationDTO GetLocationById(int id);
        LocationDTO AddNewLocation(LocationDTO newLocation);


    }
}
