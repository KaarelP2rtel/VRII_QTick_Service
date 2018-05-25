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
            var tt = _ticketTypeFactory.Transform(newTicketType);
            _uow.TicketTypes.Add(tt);
            _uow.SaveChanges();
            return _ticketTypeFactory.Transform(_uow.TicketTypes.Find(tt.TicketTypeId));
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
    }
}
