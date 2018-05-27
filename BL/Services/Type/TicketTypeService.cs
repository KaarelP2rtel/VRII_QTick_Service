using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ITicketTypeFactory _ticketTypeFactory;

        public TicketTypeService(IAppUnitOfWork uow, ITicketTypeFactory ticketTypeFactory)
        {
            _uow = uow;
            _ticketTypeFactory = ticketTypeFactory;
        }

        public TicketTypeDTO AddNewTicketType(TicketTypeDTO newTicketType)
        {
            try
            {
                var tt = _ticketTypeFactory.Transform(newTicketType);
                _uow.TicketTypes.Add(tt);
                _uow.SaveChanges();
                return _ticketTypeFactory.Transform(_uow.TicketTypes.Find(tt.TicketTypeId));
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }

        public bool DeleteTicketType(int id)
        {
            try
            {
                _uow.TicketTypes.Remove(id);
                _uow.SaveChanges();
                return true;
            }
            catch (DBConcurrencyException)
            {
                return false;
            }
        }

        public List<TicketTypeDTO> GetAllTicketTypes()
        {
            return _uow.TicketTypes
                .All()
                .Select(tt => _ticketTypeFactory.Transform(tt))
                .ToList();

        }

        public TicketTypeDTO GetTicketTypeById(int id)
        {
            return _ticketTypeFactory.Transform(_uow.TicketTypes.Find(id));
        }

        public TicketTypeDTO UpdateTicketType(TicketTypeDTO ticketType)
        {

            try
            {
                var tt = _ticketTypeFactory.Transform(ticketType);
                _uow.TicketTypes.Update(tt);
                _uow.SaveChanges();
                return GetTicketTypeById(tt.TicketTypeId);
            }
            catch (DBConcurrencyException)
            {
                return null;
            }

        }
    }
}
