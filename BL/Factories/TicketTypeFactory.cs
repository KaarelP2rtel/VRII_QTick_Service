using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface ITicketTypeFactory
    {
        TicketTypeDTO Transform(TicketType tt);
        TicketType Transform(TicketTypeDTO dto);
    }
    public class TicketTypeFactory : ITicketTypeFactory
    {
        public TicketTypeDTO Transform(TicketType tt)
        {
            return new TicketTypeDTO
            {
                TicketTypeId = tt.TicketTypeId,
                TicketTypeName = tt.Name,
                TicketTypeDescription = tt.Description

            };
        }

        public TicketType Transform(TicketTypeDTO dto)
        {
            return new TicketType
            {
                TicketTypeId = dto.TicketTypeId,
                Name = dto.TicketTypeName,
                Description = dto.TicketTypeDescription

            };
        }
    }


}
