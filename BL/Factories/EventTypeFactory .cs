using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface IEventTypeFactory
    {
        EventTypeDTO Transform(EventType et);
        EventType Transform(EventTypeDTO dto);
    }
    public class EventTypeFactory : IEventTypeFactory
    {
        public EventTypeDTO Transform(EventType et)
        {
            return new EventTypeDTO
            {
                EventTypeId = et.EventTypeId,
                EventTypeName = et.Name,
                EventTypeDescription = et.Description

            };
        }

        public EventType Transform(EventTypeDTO dto)
        {
            return new EventType
            {
                EventTypeId = dto.EventTypeId,
                Name = dto.EventTypeName,
                Description = dto.EventTypeDescription

            };
        }
    }


}
