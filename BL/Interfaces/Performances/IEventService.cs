using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    /// <summary>
    /// Interface for the EventService
    /// </summary>
    public interface IEventService
    {
        List<EventDTO> GetAllEvents();
        List<EventDTO> GetAllEventsByTypeId(int typeId);

        EventDTO GetEventById(int id);
        EventDTO AddNewEvent(EventDTO newEvent);
        bool DeleteEvent(int id);
        EventDTO UpdateEvent( EventDTO eventNew);
    }
}
