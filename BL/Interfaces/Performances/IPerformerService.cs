using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;

namespace BL.Interfaces
{
    public interface IPerformerService
    {
        List<PerformerDTO> GetAllPerformers();

        List<PerformerDTO> GetAllPerformersByTypeId(int typeId);

        PerformerDTO GetPerformerById(int personId);

        PerformerDTO AddNewPerformer(PerformerDTO newPerformer);
        PerformerDTO UpdatePerformer(PerformerDTO performer);
        bool DeletePerformer(int id);
    }
}
