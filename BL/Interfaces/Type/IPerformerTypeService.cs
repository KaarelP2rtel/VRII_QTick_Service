using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;

namespace BL.Interfaces
{
    public interface IPerformerTypeService
    {
        List<PerformerTypeDTO> GetAllPerformerTypes();
        PerformerTypeDTO GetPerformerTypeById(int id);
        PerformerTypeDTO AddNewPerformerType(PerformerTypeDTO newPerformerType);
    }
}
