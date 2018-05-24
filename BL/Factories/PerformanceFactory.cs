using BL.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Factories
{
    public interface IPerformanceFactory
    {
        PerformanceDTO Transform(Performance p);
        Performance Transform(PerformanceDTO dto);
        PerformanceDTO TransformWithPerformers(Performance p);
   

    }
    public class PerformanceFactory : IPerformanceFactory
    {
        private readonly ILocationFactory _locationFactory;
        private readonly IEventFactory _eventFactory;
        private readonly IPerformerFactory _performerFactory;

        public PerformanceFactory(ILocationFactory locationFactory, IEventFactory eventFactory, IPerformerFactory performerFactory)
        {
            _locationFactory = locationFactory;
            _eventFactory = eventFactory;
            _performerFactory = performerFactory;
        }

        public PerformanceDTO Transform(Performance p)
        {
            return new PerformanceDTO
            {
                TicketInfo = p.TicketInfo,
                PerformanceDescription = p.PerformanceDescription,
                PerformanceTime = p.PerformanceTime,
                Event = _eventFactory.Transform(p.Event),
                Location = _locationFactory.Transform(p.Location)
            };
        }

        public Performance Transform(PerformanceDTO dto)
        {
            return new Performance
            {
                TicketInfo = dto.TicketInfo,
                PerformanceDescription = dto.PerformanceDescription,
                PerformanceTime = dto.PerformanceTime,
                EventId = dto.EventId,
                LocationId = dto.LocationId     
            };
        }

        public PerformanceDTO TransformWithPerformers(Performance p)
        {
            var dto = Transform(p);
            if (dto == null) return null;
            dto.Performers = p.Performers.Select(pe => _performerFactory.Transform(pe)).ToList();
            return dto;
        }
    }


}
