﻿using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface IEventTypeSerivce
    {
        List<EventTypeDTO> GetAllEventTypes();
        EventTypeDTO GetEventTypeById(int id);
        EventTypeDTO AddNewEventType(EventTypeDTO newEventType);
    }
}