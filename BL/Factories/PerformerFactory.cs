using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;
using Domain;

namespace BL.Factories
{
    public interface IPerformerFactory
    {
        PerformerDTO Transform(Performer p);
        Performer Transform(PerformerDTO dto);
    }

    public class PerformerFactory : IPerformerFactory
    {
        private readonly IPerformerTypeFactory _performerTypeFactory;

        public PerformerFactory(IPerformerTypeFactory performerTypeFactory)
        {
            _performerTypeFactory = performerTypeFactory;
        }

        public PerformerDTO Transform(Performer p)
        {
            return new PerformerDTO
            {
                PerformerName = p.PerformerName,
                PerformerDescription = p.PerformerDescription,
                PerformerPage = p.PerformerPage,
                PerformerType = _performerTypeFactory.Transform(p.PerformerType)
            };
        }

        public Performer Transform(PerformerDTO dto)
        {
            return new Performer
            {
                PerformerName = dto.PerformerName,
                PerformerDescription = dto.PerformerDescription,
                PerformerPage = dto.PerformerPage,
                PerformerTypeId = dto.PerformerId
            };
        }

    }
}

