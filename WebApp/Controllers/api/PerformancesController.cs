using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DTO;
using BL.Interfaces;
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
        private readonly ILocationTypeService _locationTypeService;

        public PerformancesController(ILocationService locationService, ILocationTypeService locationTypeService)
        {
            _locationService = locationService;
            _locationTypeService = locationTypeService;
        }

        [HttpGet]
        [Route("GetLocations")]
        public List<LocationDTO> GetLocations() => _locationService.GetAllLocations();

        [HttpPost]
        [Route("AddLocation")]
        public LocationDTO AddLocation([FromBody] LocationDTO newLocation) => _locationService.AddNewLocation(newLocation);
        [HttpPost]
        [Route("AddLocationType")]
        public LocationTypeDTO AddLocationType([FromBody] LocationTypeDTO newLocationType) => _locationTypeService.AddNewLocationType(newLocationType);
    }
}