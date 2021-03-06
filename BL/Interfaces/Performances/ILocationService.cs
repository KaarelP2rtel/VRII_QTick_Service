﻿using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    /// <summary>
    /// Interface for LocationService
    /// </summary>
    public interface ILocationService
    {
        List<LocationDTO> GetAllLocations();
        List<LocationDTO> GetAllLocationsByTypeId(int typeId);

        LocationDTO GetLocationById(int id);
        LocationDTO AddNewLocation(LocationDTO newLocation);
        bool DeleteLocation(int id);
        LocationDTO UpdateLocation(LocationDTO location);
    }
}
