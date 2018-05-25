using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BL.DTO;
using BL.DTO.Users;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/User")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.User)]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("Tickets")]
        public List<TicketDTO> GetTicketsForUser() => throw new NotImplementedException();

        [HttpGet]
        [Route("Tickets/{id}")]
        public List<TicketDTO> GetTicketForUser() => throw new NotImplementedException();

        [HttpGet]
        [Route("Invoices")]
        public List<InvoiceDTO> GetInvoicesForUser() => throw new NotImplementedException();

        [HttpGet]
        [Route("Invoices/{id}")]
        public List<InvoiceDTO> GetInvoiceForUser() => throw new NotImplementedException();

        [HttpGet]
        [Route("Register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] NewUserDTO newUser) => throw new NotImplementedException();

      


    }
}