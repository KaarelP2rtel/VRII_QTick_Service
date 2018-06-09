using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    /// <summary>
    /// Interface for EventFactory
    /// </summary>
    public interface IEventFactory
    {
        EventDTO Transform(Event e);
        Event Transform(EventDTO dto);
    }

     public class EventFactory : IEventFactory
    {
        private readonly IEventTypeFactory _eventTypeFactory;

        /// <summary>
        /// This factory used to get information from eventTypeFactory for EventFactory
        /// </summary>
        /// <param name="eventTypeFactory"></param>

        public EventFactory(IEventTypeFactory eventTypeFactory)
        {
            _eventTypeFactory = eventTypeFactory;
        }

        /// <summary>
        /// This method transforms EventDTO to Event
        /// </summary>
        /// <param name="l"></param>
        /// <returns>EventDTO of the Event</returns>

        public EventDTO Transform(Event l)
        {
            if (l == null) return null;
            return new EventDTO
            {
                EventId=l.EventId,
                EventName = l.EventName,
                ImageLink = l.ImageLink,
                EventDescription= l.EventDescription,
                EventPage=l.EventPage,
                EventDuration=l.EventDuration,
                EventType = _eventTypeFactory.Transform(l.EventType)??null
            };
        }

        /// <summary>
        /// This method transforms Event to EventDTO
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Event of the EventDTO</returns>

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
                EventTypeId = dto.EventTypeId

            };
        }


    }


}
