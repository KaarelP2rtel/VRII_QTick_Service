using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;

namespace BL.Interfaces
{
    public interface IPerformerService
    {
        List<PerformerDTO> GetAllPerformers();

        PerformerDTO GetAllPerformerByTypeId(int typeId);

        PerformerDTO GetPerformerById(int personId);

        PerformerDTO AddNewPerformer(PerformerDTO newPerformer);
    }
}
