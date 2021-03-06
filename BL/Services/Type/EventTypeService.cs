﻿using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class EventTypeService : IEventTypeService
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
            try
            {
                var et = _eventTypeFactory.Transform(newEventType);
                _uow.EventTypes.Add(et);
                _uow.SaveChanges();
                return _eventTypeFactory.Transform(et);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }

        public bool DeleteEventType(int id)
        {
            try
            {
                _uow.EventTypes.Remove(id);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }

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

        public EventTypeDTO UpdateEventType(EventTypeDTO eventType)
        {
            try
            {
                var et = _uow.EventTypes.Update(_eventTypeFactory.Transform(eventType));
                _uow.SaveChanges();
                return _eventTypeFactory.Transform(et);
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }


        }
    }
}
