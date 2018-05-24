using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;
using Domain;

namespace BL.Factories
{
    public interface IPerformerTypeFactory
    {
        PerformerTypeDTO Transform(PerformerType pt);
        PerformerType Transform(PerformerTypeDTO dto);
    }
    public class PerformerTypeFactory : IPerformerTypeFactory
    {
        public PerformerTypeDTO Transform(PerformerType pt)
        {
            return new PerformerTypeDTO
            {
                PerformerTypeId = pt.PerformerTypeId,
                PerformerTypeName = pt.Name,
                PerformerTypeDescription = pt.Description
            };
        }

        public PerformerType Transform(PerformerTypeDTO dto)
        {
            return new PerformerType
            {
                PerformerTypeId = dto.PerformerTypeId,
                Name = dto.PerformerTypeName,
                Description = dto.PerformerTypeDescription
            };

        }
    }


}
