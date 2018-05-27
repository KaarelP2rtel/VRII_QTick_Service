using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EventService : IEventService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IEventFactory _eventFactory;

        public EventService(IAppUnitOfWork uow, IEventFactory eventFactory)
        {
            _uow = uow;
            _eventFactory = eventFactory;
        }

        public EventDTO AddNewEvent(EventDTO newEvent)
        {
            try
            {
                var e = _eventFactory.Transform(newEvent);
                _uow.Events.Add(e);
                _uow.SaveChanges();
                return _eventFactory.Transform(_uow.Events.Find(e.EventId));
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }

        public bool DeleteEvent(int id)
        {
            try
            {
                _uow.Events.Remove(id);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }

        }

        public List<EventDTO> GetAllEvents()
        {
            return _uow.Events
                .All()
                .Select(e => _eventFactory.Transform(e))
                .ToList();
        }

        public List<EventDTO> GetAllEventsByTypeId(int typeId)
        {
            return _uow.Events
               .AllByTypeId(typeId)
               .Select(e => _eventFactory.Transform(e))
               .ToList();
        }

        public EventDTO GetEventById(int id)
        {
            return _eventFactory.Transform(_uow.Events.Find(id));
        }

        public EventDTO UpdateEvent(EventDTO eventNew)
        {
            try
            {
                var e = _uow.Events.Update(_eventFactory.Transform(eventNew));
                _uow.SaveChanges();
                return _eventFactory.Transform(e);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }
    }
}
