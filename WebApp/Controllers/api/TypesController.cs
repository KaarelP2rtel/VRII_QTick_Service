using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTO;
using BL.Interfaces;
using Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Types")]
    public class TypesController : Controller
    {
        private readonly IEventTypeService _eventTypeService;
        private readonly ILocationTypeService _locationTypeService;
        private readonly IPerformerTypeService _performerTypeService;
        private readonly ITicketTypeService _ticketTypeService;

        public TypesController(
            IEventTypeService eventTypeService,
            ILocationTypeService locationTypeService,
            IPerformerTypeService performerTypeService,
            ITicketTypeService ticketTypeService)
        {
            _eventTypeService = eventTypeService;
            _locationTypeService = locationTypeService;
            _performerTypeService = performerTypeService;
            _ticketTypeService = ticketTypeService;
        }

        #region TicketTypes
        [HttpGet]
        [Route("TicketTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<TicketTypeDTO> GetTicketTypes() => _ticketTypeService.GetAllTicketTypes();

        [HttpGet]
        [Route("TicketTypes/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public TicketTypeDTO GetTicketTypeById([FromRoute] int id) => _ticketTypeService.GetTicketTypeById(id);

        [HttpPost]
        [Route("TicketTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public TicketTypeDTO AddTicketType([FromBody] TicketTypeDTO newTicketType) => _ticketTypeService.AddNewTicketType(newTicketType);
        #endregion

        #region LocationTypes
        [HttpGet]
        [Route("LocationTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<LocationTypeDTO> GetLocationTypes() => _locationTypeService.GetAllLocationTypes();

        [HttpGet]
        [Route("LocationTypes/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public LocationTypeDTO GetLocationTypeById([FromRoute] int id) => _locationTypeService.GetLocationTypeById(id);

        [HttpPost]
        [Route("LocationTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public LocationTypeDTO AddLocationType([FromBody] LocationTypeDTO newLocationType) => _locationTypeService.AddNewLocationType(newLocationType);
        #endregion
        
        #region PerformerTypes
        [HttpGet]
        [Route("PerformerTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<PerformerTypeDTO> GetPerformerTypes() => _performerTypeService.GetAllPerformerTypes();

        [HttpGet]
        [Route("PerformerTypes/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public PerformerTypeDTO GetPerformerTypeById([FromRoute] int id) => _performerTypeService.GetPerformerTypeById(id);

        [HttpPost]
        [Route("PerformerTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public PerformerTypeDTO AddPerformerType([FromBody] PerformerTypeDTO newPerformerType) => _performerTypeService.AddNewPerformerType(newPerformerType);
        #endregion
        
        #region EventTypes
        [HttpGet]
        [Route("EventTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<EventTypeDTO> GetEventTypes() => _eventTypeService.GetAllEventTypes();

        [HttpGet]
        [Route("EventTypes/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public EventTypeDTO GetEventTypeById([FromRoute] int id) => _eventTypeService.GetEventTypeById(id);

        [HttpPost]
        [Route("EventTypes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public EventTypeDTO AddEventType([FromBody] EventTypeDTO newEventType) => _eventTypeService.AddNewEventType(newEventType);
        #endregion

    }
}