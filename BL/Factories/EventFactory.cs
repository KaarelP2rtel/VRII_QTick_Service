using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface IEventFactory
    {
        EventDTO Transform(Event e);
        Event Transform(EventDTO dto);


    }
    public class EventFactory : IEventFactory
    {
        private readonly IEventTypeFactory _eventTypeFactory;

        public EventFactory(IEventTypeFactory eventTypeFactory)
        {
            _eventTypeFactory = eventTypeFactory;
        }

        public EventDTO Transform(Event l)
        {
            if (l == null) return null;
            return new EventDTO
            {
                EventName = l.EventName,
                ImageLink = l.ImageLink,
                EventDescription= l.EventDescription,
                EventPage=l.EventPage,
                EventDuration=l.EventDuration,
                EventType = _eventTypeFactory.Transform(l.EventType)
            };
        }

        public Event Transform(EventDTO dto)
        {
            if (dto == null) return null;
            return new Event
            {
                EventName = dto.EventName,
                ImageLink = dto.ImageLink,
                EventDescription = dto.EventDescription,
                EventPage = dto.EventPage,
                EventDuration = dto.EventDuration,
                EventTypeId = dto.EventId

            };
        }


    }


}
