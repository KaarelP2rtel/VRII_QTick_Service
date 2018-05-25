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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<LocationDTO> GetLocations() => _locationService.GetAllLocations();

        [HttpGet]
        [Route("Locations/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public LocationDTO GetLocation([FromRoute] int id) => _locationService.GetLocationById(id);

        [HttpPost]
        [Route("Locations")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddLocation([FromBody] LocationDTO newLocation)
        {
            if (TryValidateModel(newLocation)){
                return Ok(_locationService.AddNewLocation(newLocation));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("LocationsOfType/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<LocationDTO> LocationsOfType([FromRoute] int id) => _locationService.GetAllLocationsByTypeId(id);
        #endregion

        #region Events
        [HttpGet]
        [Route("Events")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<EventDTO> GetEvents() => _eventService.GetAllEvents();

        [HttpGet]
        [Route("Events/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public EventDTO GetEvent([FromRoute] int id) => _eventService.GetEventById(id);

        [HttpPost]
        [Route("Events")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddEvent([FromBody] EventDTO newEvent)
        {
            if (TryValidateModel(newEvent))
            {
                return Ok(_eventService.AddNewEvent(newEvent));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("EventsOfType/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<EventDTO> EventsOfType([FromRoute] int id) => _eventService.GetAllEventsByTypeId(id);
        #endregion

        #region Performers
        [HttpGet]
        [Route("Performers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<PerformerDTO> GetPerformers() => _performerService.GetAllPerformers();

        [HttpGet]
        [Route("Performers/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public PerformerDTO GetPerformer([FromRoute] int id) => _performerService.GetPerformerById(id);

        [HttpPost]
        [Route("Performers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddPerformer([FromBody] PerformerDTO newPerformer)
        {
            if (TryValidateModel(newPerformer))
            {
                return Ok(_performerService.AddNewPerformer(newPerformer));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("PerformersOfType/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<PerformerDTO> PerformersOfType([FromRoute] int id) => _performerService.GetAllPerformersByTypeId(id);
        #endregion

        #region Performances
        [HttpGet]
        [Route("Performances")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<PerformanceDTO> GetPerformances() => _performanceService.GetPerformances();

        [HttpGet]
        [Route("Performances/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public PerformanceDTO GetPerformance([FromRoute] int id) => _performanceService.GetPerformanceById(id);

        [HttpPost]
        [Route("Performances")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public PerformanceDTO AddPerformance([FromBody] PerformanceDTO newPerformance) => _performanceService.AddNewPerformance(newPerformance);

        [HttpGet]
        [Route("PerformancesWithPerformers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<PerformanceDTO> GetPerformancesWithPerformers() => _performanceService.GetPerformancesWithPerformers();

        [HttpGet]
        [Route("PerformancesWithPerformers/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public PerformanceDTO GetPerformanceWithPerformers([FromRoute] int id) => _performanceService.GetPerformanceByIdWithPerformer(id);

        [HttpPost]
        [Route("AddPerformerToPerformance")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public IActionResult AddPerformer([FromBody] PerformancePerformerDTO newPerformer)
        {
            if (TryValidateModel(newPerformer))
            {
                return Ok(_performanceService.AddPerformerToPerformance(newPerformer));
            }
            return BadRequest();
            
        }
        #endregion



    }
}