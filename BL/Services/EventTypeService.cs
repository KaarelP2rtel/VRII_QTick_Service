using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class EventTypeService : IEventTypeSerivce
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IEventTypeFactory _eventTypeFactory;

        public EventTypeService(IAppUnitOfWork uow, IEventTypeFactory eventTypeFactory)
        {
            _uow = uow;
            _eventTypeFactory = eventTypeFactory;
        }

        public EventTypeDTO AddNewEventType(EventTypeDTO newEventType)
        {
            var et = _eventTypeFactory.Transform(newEventType);
            _uow.EventTypes.Add(et);
            _uow.SaveChanges();
            return _eventTypeFactory.Transform(et);
        }

        public List<EventTypeDTO> GetAllEventTypes()
        {
            return _uow.EventTypes
                .All()
                .Select(et => _eventTypeFactory.Transform(et))
                .ToList();

        }

        public EventTypeDTO GetEventTypeById(int id)
        {
             return _eventTypeFactory.Transform(_uow.EventTypes.Find(id));
        }
    }
}
