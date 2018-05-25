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
        TicketDTO TransformWithUser(Ticket ticket);
    }
    public class TicketFactory : ITicketFactory
    {
        private readonly ITicketTypeFactory _ticketTypeFactory;
        private readonly IPerformanceFactory _performanceFactory;
        private readonly IApplicationUserFactory _applicationUserFactory;

        public TicketFactory(
            ITicketTypeFactory ticketTypeFactory,
            IPerformanceFactory performanceFactory,
            IApplicationUserFactory applicationUserFactory)
        {
            _ticketTypeFactory = ticketTypeFactory;
            _performanceFactory = performanceFactory;
            _applicationUserFactory = applicationUserFactory;
        }

        public TicketDTO Transform(Ticket t)
        {
            if (t == null) return null;
            return new TicketDTO
            {
                TicketId = t.TicketId,
                TicketNr = t.TicketNr,
                DatePurchased = t.DatePurchased,
                TicketType = _ticketTypeFactory.Transform(t.TicketType)
            };
        }

        public Ticket Transform(TicketDTO dto)
        {
            if (dto == null) return null;
            return new Ticket
            {
                TicketNr = dto.TicketNr,
                DatePurchased = dto.DatePurchased,
                TicketTypeId = dto.TicketTypeId,
                PerformanceId = dto.PerformanceId,
                ApplicationUserId=dto.ApplicationUserId
            };
        }

        public TicketDTO TransformWithPerformance(Ticket t)
        {
            if (t == null) return null;
            return new TicketDTO
            {
                TicketId=t.TicketId,
                TicketNr = t.TicketNr,
                DatePurchased = t.DatePurchased,
                TicketType = _ticketTypeFactory.Transform(t.TicketType),
                Performance = _performanceFactory.Transform(t.Performance)
            };
        }

        public TicketDTO TransformWithUser(Ticket t)
        {
            if (t == null) return null;
            return new TicketDTO
            {
                TicketId = t.TicketId,
                TicketNr = t.TicketNr,
                DatePurchased = t.DatePurchased,
                TicketTypeId = t.TicketTypeId,
                ApplicationUser = _applicationUserFactory.Transform(t.ApplicationUser)
            };
        }
    }
}


