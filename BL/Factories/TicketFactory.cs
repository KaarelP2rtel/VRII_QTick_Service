using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Factories
{
    public interface ITicketFactory
    {
        TicketDTO Transform(Ticket t);
        Ticket Transform(TicketDTO dto);
        TicketDTO TransformWithPerformance(Ticket t);
        
    }
    public class TicketFactory : ITicketFactory
    {
        private readonly ITicketTypeFactory _ticketTypeFactory;
        private readonly IPerformanceFactory _performanceFactory;

        public TicketFactory(ITicketTypeFactory ticketTypeFactory, IPerformanceFactory performanceFactory)
        {
            _ticketTypeFactory = ticketTypeFactory;
            _performanceFactory = performanceFactory;
        }

        public TicketDTO Transform(Ticket t)
        {
            return new TicketDTO
            {
                TicketNr = t.TicketNr,
                DatePurchased = t.DatePurchased,
                TicketType = _ticketTypeFactory.Transform(t.TicketType)
            };
        }

        public Ticket Transform(TicketDTO dto)
        {
            return new Ticket
            {
                TicketNr = dto.TicketNr,
                DatePurchased = dto.DatePurchased,
                TicketTypeId = dto.TicketTypeId
            };
        }

        public TicketDTO TransformWithPerformance(Ticket t)
        {
            return new TicketDTO
            {
                TicketNr = t.TicketNr,
                DatePurchased = t.DatePurchased,
                TicketType = _ticketTypeFactory.Transform(t.TicketType),
                Performance = _performanceFactory.Transform(t.Performance)
            };
        }
    }


}
