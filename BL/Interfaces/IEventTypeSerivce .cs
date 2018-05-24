using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface ILocationTypeSerivce
    {
        List<LocationTypeDTO> GetAllLocationTypes();
        LocationTypeDTO GetLocationTypeById(int id);
        LocationTypeDTO AddNewLocationType(LocationTypeDTO newLocationType);
    }
}
