using System.Collections.Generic;
using System.Linq;
using BL.DTO;
using BL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        private object Errors
        {
            get => ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
        }

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
        public IActionResult AddTicketType([FromBody] TicketTypeDTO newTicketType)
        {
            if (TryValidateModel(newTicketType))
            {
                return Ok(_ticketTypeService.AddNewTicketType(newTicketType));
            }

            return BadRequest(Errors);
        }

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
        public IActionResult AddLocationType([FromBody] LocationTypeDTO newLocationType)
        {

            if (TryValidateModel(newLocationType))
            {
                return Ok(_locationTypeService.AddNewLocationType(newLocationType));
            }

            return BadRequest(Errors);
        }

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
        public IActionResult AddPerformerType([FromBody] PerformerTypeDTO newPerformerType)
        {
        
            if (TryValidateModel(newPerformerType))
            {
                return Ok(_performerTypeService.AddNewPerformerType(newPerformerType));
            }

            return BadRequest(Errors);
        }
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
        public IActionResult AddEventType([FromBody] EventTypeDTO newEventType)
        {
            if (TryValidateModel(newEventType))
            {
                return Ok(_eventTypeService.AddNewEventType(newEventType));
            }

            return BadRequest(Errors);
        }
        #endregion

    }
}