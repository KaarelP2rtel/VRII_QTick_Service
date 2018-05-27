using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BL.DTO;
using BL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/User")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
    public class UserController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IInvoiceService _invoiceService;
        private readonly IApplicationUserService _applicationUserService;

        public UserController(
            ITicketService ticketService, 
            IInvoiceService invoiceService, 
            IApplicationUserService applicationUserService)
        {
            _ticketService = ticketService;
            _invoiceService = invoiceService;
            _applicationUserService = applicationUserService;
        }

        private object Errors
        {
            get
            {
                return ModelState
               .Where(x => x.Value.Errors.Count > 0)
               .Select(x => new { x.Value.Errors })
               .ToArray();
            }
        }



        [HttpGet]
        [Route("Tickets")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<TicketDTO> GetTicketsForUser() => _ticketService.GetTicketsForUser(User.Identity.Name);

        [HttpGet]
        [Route("Tickets/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public TicketDTO GetTicketForUser([FromRoute] int id) => _ticketService.GetTicketForUser(User.Identity.Name, id);

        [HttpGet]
        [Route("Invoices")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public List<InvoiceDTO> GetInvoicesForUser() => _invoiceService.GetInvoicesForUser(User.Identity.Name);

        [HttpGet]
        [Route("Invoices/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
        public InvoiceDTO GetInvoiceForUser([FromBody] int id) => _invoiceService.GetInvoiceForUser(User.Identity.Name, id);

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] NewUserDTO newUser)
        {
            
            if (TryValidateModel(newUser))
            {
                if(_applicationUserService.GetApplicationUserByName(newUser.UserName) != null)
                {
#warning Needs better errror reporting and Password requirements checking
                    return BadRequest("Username taken");
                }
                return Ok(_applicationUserService.AddNewApplicationUser(newUser));
              
            }
            return BadRequest(Errors);
        }
    }
}