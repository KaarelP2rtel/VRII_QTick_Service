using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [Route("Tickets")]
        public List<TicketTypeDTO> GetTicketTypes() => _ticketTypeService.GetAllTicketTypes();

        [HttpGet]
        [Route("Tickets/{id}")]
        public TicketTypeDTO GetTicketTypeById([FromRoute] int id) => _ticketTypeService.GetTicketTypeById(id);

        [HttpPost]
        [Route("Tickets")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddTicketType([FromBody] TicketTypeDTO newTicketType)
        {
            if (newTicketType == null) return BadRequest();

            if (TryValidateModel(newTicketType) || newTicketType.TicketTypeId!=0)
            {
                var tt = _ticketTypeService.AddNewTicketType(newTicketType);
                if (tt == null) return StatusCode(418);
                return Ok();

            }

            return BadRequest(Errors);
        }

        [HttpPut]
        [Route("Tickets")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdateTicketType([FromBody] TicketTypeDTO ticketType)
        {
            if (ticketType == null) return BadRequest();
            //Manual validation
            if (TryValidateModel(ticketType) || ticketType.TicketTypeId == 0)
            {
                var tt = _ticketTypeService.UpdateTicketType(ticketType);
                if (tt == null) return NotFound();
                return Ok();

            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Tickets/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeleteTicketType([FromRoute] int id)
        {
            if (_ticketTypeService.DeleteTicketType(id))
            {
                return Ok();
            }

            return NotFound();
        }



        #endregion

        #region LocationTypes
        [HttpGet]
        [Route("Locations")]
        public List<LocationTypeDTO> GetLocationTypes() => _locationTypeService.GetAllLocationTypes();

        [HttpGet]
        [Route("Locations/{id}")]

        public LocationTypeDTO GetLocationTypeById([FromRoute] int id) => _locationTypeService.GetLocationTypeById(id);

        [HttpPost]
        [Route("Locations")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddLocationType([FromBody] LocationTypeDTO newLocationType)
        {
            if (newLocationType == null) return BadRequest();
            if (TryValidateModel(newLocationType) ||newLocationType.LocationTypeId != 0)
            {
                var lt = _locationTypeService.AddNewLocationType(newLocationType);
                if (lt == null) return StatusCode(418);
                return Ok();
            }

            return BadRequest(Errors);
        }

        [HttpPut]
        [Route("Locations")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdateLocationType([FromBody] LocationTypeDTO locationType)
        {
            if (locationType == null) return BadRequest();
            if (TryValidateModel(locationType) || locationType.LocationTypeId == 0)
            {
                var lt = _locationTypeService.UpdateLocationType(locationType);
                if (lt == null) return NotFound();
                return Ok();
            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Locations/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeleteLocationType([FromRoute] int id)
        {
            if (_locationTypeService.DeleteLocationType(id))
            {
                return Ok();
            }
            return NotFound();
        }

        #endregion

        #region PerformerTypes
        [HttpGet]
        [Route("Performers")]
        public List<PerformerTypeDTO> GetPerformerTypes() => _performerTypeService.GetAllPerformerTypes();

        [HttpGet]
        [Route("Performers{id}")]
        public PerformerTypeDTO GetPerformerTypeById([FromRoute] int id) => _performerTypeService.GetPerformerTypeById(id);

        [HttpPost]
        [Route("Performers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddPerformerType([FromBody] PerformerTypeDTO newPerformerType)
        {
            if (newPerformerType == null) return BadRequest();

            if (TryValidateModel(newPerformerType) ||newPerformerType.PerformerTypeId !=0)
            {
                var pt = _performerTypeService.AddNewPerformerType(newPerformerType);
                if (pt == null) return StatusCode(418);
                return Ok(pt);
            }

            return BadRequest(Errors);
        }

        [HttpPut]
        [Route("Performers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdatePerformerType([FromBody] PerformerTypeDTO performerType)
        {
            if ( performerType == null) return BadRequest();

            if (TryValidateModel(performerType) || performerType.PerformerTypeId == 0)
            {
                var pt = _performerTypeService.UpdatePerformerType(performerType);
                if (pt == null) return NotFound();
                return Ok(pt);
            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Performers/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeletePerformerType([FromRoute] int id)
        {
            if (_performerTypeService.DeletePerformerType(id))
            {
                return StatusCode(418);
            }
            return NotFound();
        }
        #endregion

        #region EventTypes
        [HttpGet]
        [Route("Events")]
        public List<EventTypeDTO> GetEventTypes() => _eventTypeService.GetAllEventTypes();

        [HttpGet]
        [Route("Events/{id}")]
        public EventTypeDTO GetEventTypeById([FromRoute] int id) => _eventTypeService.GetEventTypeById(id);

        [HttpPost]
        [Route("Events")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddEventType([FromBody] EventTypeDTO newEventType)
        {
            if (newEventType== null) return BadRequest();

            if (TryValidateModel(newEventType) ||newEventType.EventTypeId != 0)
            {
                var et = _eventTypeService.AddNewEventType(newEventType);
                if(et ==null) return StatusCode(418);
                return Ok();
            }

            return BadRequest(Errors);
        }

        [HttpPut]
        [Route("Events")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdateEventType([FromBody] EventTypeDTO eventType)
        {
            if (eventType == null) return BadRequest();

            if (TryValidateModel(eventType) || eventType.EventTypeId == 0)
            {
                var et = _eventTypeService.UpdateEventType(eventType);
                if (et == null) return NotFound();
                return Ok(et);
            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Events/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeleteEventType([FromRoute] int id)
        {
            if (_eventTypeService.DeleteEventType(id))
            {
                return Ok();
            }

            return NotFound();
        }
        #endregion

    }
}