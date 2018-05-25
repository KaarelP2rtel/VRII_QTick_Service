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
    public class TicketService : ITicketService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly ITicketFactory _ticketFactory;

        public TicketService(IAppUnitOfWork uow, ITicketFactory ticketFactory)
        {
            _uow = uow;
            _ticketFactory = ticketFactory;
        }

        public TicketDTO AddNewTicket(TicketDTO ticket)
        {
            throw new NotImplementedException();
        }

        public List<TicketDTO> GetAllTickets()
        {
            return _uow.Tickets.All().Select(t => _ticketFactory.Transform(t)).ToList();
        }

        public TicketDTO GetTicketById(int id)
        {
            return _ticketFactory.Transform(_uow.Tickets.Find(id));
        }

        public TicketDTO GetTicketByIdWithPerformance(int id)
        {
            return _ticketFactory.TransformWithPerformance(_uow.Tickets.Find(id));
        }
    }
}
