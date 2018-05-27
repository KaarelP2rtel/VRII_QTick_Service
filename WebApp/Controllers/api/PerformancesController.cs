using System.Collections.Generic;
using System.Linq;
using BL.DTO;
using BL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Performances")]
    [AllowAnonymous]
    public class PerformancesController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IEventService _eventService;
        private readonly IPerformerService _performerService;
        private readonly IPerformanceService _performanceService;

        private object Errors
        {
            get => ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
        }

        public PerformancesController(
            ILocationService locationService,
            IEventService eventService,
            IPerformerService performerService,
            IPerformanceService performanceService)
        {
            _locationService = locationService;
            _eventService = eventService;
            _performerService = performerService;
            _performanceService = performanceService;
        }



        #region Locations
        [HttpGet]
        [Route("Locations")]
        public List<LocationDTO> GetLocations() => _locationService.GetAllLocations();

        [HttpGet]
        [Route("Locations/{id}")]
        public LocationDTO GetLocation([FromRoute] int id) => _locationService.GetLocationById(id);

        [HttpPost]
        [Route("Locations")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddLocation([FromBody] LocationDTO newLocation)
        {
            if (newLocation== null) return BadRequest();

            if (TryValidateModel(newLocation) || newLocation.LocationId!=0)
            {
                var l = _locationService.AddNewLocation(newLocation);
                if (l == null) return StatusCode(418);
                return Ok(l);
            }
            return BadRequest(Errors);
        }

        [HttpGet]
        [Route("Locations/OfType/{id}")]
        public List<LocationDTO> LocationsOfType([FromRoute] int id) => _locationService.GetAllLocationsByTypeId(id);

        [HttpPut]
        [Route("Locations")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdateLocation([FromBody] LocationDTO location)
        {

            if (location == null) return BadRequest();
            if (TryValidateModel(location) || location.LocationId == 0)
            {
                var l = _locationService.UpdateLocation(location);
                if (l == null) return NotFound();
                return Ok(l);
            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Locations/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeleteLocation([FromRoute] int id)
        {
            if (_locationService.DeleteLocation(id))
            {
                return Ok();
            }

            return NotFound();
        }
        #endregion

        #region Events
        [HttpGet]
        [Route("Events")]
        public List<EventDTO> GetEvents() => _eventService.GetAllEvents();

        [HttpGet]
        [Route("Events/{id}")]
        public EventDTO GetEvent([FromRoute] int id) => _eventService.GetEventById(id);

        [HttpPost]
        [Route("Events")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddEvent([FromBody] EventDTO newEvent)
        {
            if ( newEvent== null) return BadRequest();
            if (TryValidateModel(newEvent) || newEvent.EventId!=0)
            {
                var e = _eventService.AddNewEvent(newEvent);
                if (e == null) return StatusCode(418);
                return Ok(e);
            }
            return BadRequest(Errors);
        }

        [HttpGet]
        [Route("Events/OfType/{id}")]
        public List<EventDTO> EventsOfType([FromRoute] int id) => _eventService.GetAllEventsByTypeId(id);

        [HttpPut]
        [Route("Events/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdateEvent([FromBody] EventDTO eventNew)
        {
            if (eventNew == null) return BadRequest();
            if (TryValidateModel(eventNew) || eventNew.EventId == 0)
            {
                var e = _eventService.UpdateEvent(eventNew);
                if (e == null) return NotFound();
                return Ok(e);
            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Events/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeleteEvent([FromRoute] int id)
        {
            if (_eventService.DeleteEvent(id))
            {
                return Ok();
            }

            return NotFound();
        }
        #endregion

        #region Performers
        [HttpGet]
        [Route("Performers")]
        public List<PerformerDTO> GetPerformers() => _performerService.GetAllPerformers();

        [HttpGet]
        [Route("Performers/{id}")]
        public PerformerDTO GetPerformer([FromRoute] int id) => _performerService.GetPerformerById(id);

        [HttpPost]
        [Route("Performers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddPerformer([FromBody] PerformerDTO newPerformer)
        {
            if (newPerformer == null) return BadRequest();
            if (TryValidateModel(newPerformer) || newPerformer.PerformerId!=0)
            {
                var p = _performerService.AddNewPerformer(newPerformer);
                if (p == null) return StatusCode(418);
                return Ok(p);
            }
            return BadRequest(Errors);
        }

        [HttpGet]
        [Route("PerformersOfType/{id}")]
        public List<PerformerDTO> PerformersOfType([FromRoute] int id) => _performerService.GetAllPerformersByTypeId(id);

        [HttpPut]
        [Route("Performers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdatePerformer([FromBody] PerformerDTO performer)
        {
            if (performer == null) return BadRequest();
            if (TryValidateModel(performer) || performer.PerformerId == 0)
            {
                var p = _performerService.UpdatePerformer(performer);
                if (p == null) return NotFound();
                return Ok();
            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Performers/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeletePerformer([FromRoute] int id)
        {
            if (_performerService.DeletePerformer(id))
            {
                return Ok();
            }

            return NotFound();
        }


        #endregion

        #region Performances
        [HttpGet]
        [Route("Performances")]
        public List<PerformanceDTO> GetPerformances() => _performanceService.GetPerformances();

        [HttpGet]
        [Route("Performances/{id}")]
        public PerformanceDTO GetPerformance([FromRoute] int id) => _performanceService.GetPerformanceById(id);

        [HttpPost]
        [Route("Performances")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddPerformance([FromBody] PerformanceDTO newPerformance)
        {
            if ( newPerformance == null) return BadRequest();
            if (TryValidateModel(newPerformance) || newPerformance.PerformanceId !=0)
            {
                var p = _performanceService.AddNewPerformance(newPerformance);
                if (p == null) return StatusCode(418);
                return Ok(p);
            }
            return BadRequest(Errors);
        }


        [HttpPut]
        [Route("Performances")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult UpdatePerformance([FromBody] PerformanceDTO performance)
        {
            if ( performance== null) return BadRequest();
            if (TryValidateModel(performance) || performance.PerformanceId == 0)
            {
                var p = _performanceService.UpdatePerformance(performance);
                if (p == null) return NotFound();
                return Ok(p);
            }

            return BadRequest(Errors);
        }


        [HttpDelete]
        [Route("Performances/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult DeletePerformance([FromRoute] int id)
        {
            if (_performanceService.DeletePerformance(id))
            {
                return Ok();
            }

            return NotFound();
        }



        [HttpGet]
        [Route("Performances/WithPerformers")]
        public List<PerformanceDTO> GetPerformancesWithPerformers() => _performanceService.GetPerformancesWithPerformers();

        [HttpGet]
        [Route("Performances/{id}/WithPerformers")]
        public PerformanceDTO GetPerformanceWithPerformers([FromRoute] int id) => _performanceService.GetPerformanceByIdWithPerformer(id);






        #endregion

        #region PerformancePerformers
        [HttpPost]
        [Route("Performances/{performanceId}/AddPerformer/{performerId}")]
        [Route("Performers/{performerId}/AddPerformance/{performanceId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddPerformerToPerformance([FromRoute] int performanceId, [FromRoute] int performerId)
        {
            //Did not want to redo service method, so manually created DTO instead

            var pp = _performanceService.AddPerformerToPerformance(
                new PerformancePerformerDTO
                {
                    PerformanceId = performanceId,
                    PerformerId = performerId
                });
            if (pp == null) return StatusCode(418);
            return Ok();




        }

        [HttpPost]
        [Route("Performances/{performanceId}/RemovePerformer/{performerId}")]
        [Route("Performers/{performerId}/RemovePerformance/{performanceId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult RemovePerformerFromPerformance([FromRoute] int performanceId, [FromRoute] int performerId)
        {
            if (_performanceService.RemovePerformerFromPerformance(performanceId, performerId))
            {
                return Ok();
            }
            return NotFound();

        }
        #endregion

    }
}