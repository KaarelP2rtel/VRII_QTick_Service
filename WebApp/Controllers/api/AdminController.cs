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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using WebApp.Models;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Admin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly ITicketService _ticketService;
        private readonly IInvoiceService _invoiceService;
        private object Errors
        {
            get => ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
        }



        public AdminController(
            IApplicationUserService applicationUserService,
            ITicketService ticketService,
            IInvoiceService invoiceService)
        {
            _applicationUserService = applicationUserService;
            _ticketService = ticketService;
            _invoiceService = invoiceService;
        }

        #region Users
        [HttpGet]
        [Route("Users")]
        
        public List<ApplicationUserDTO> GetAllUsers() => _applicationUserService.GetAllApplicationUsers();
        #endregion

        #region Tickets
        [HttpGet]
        [Route("Tickets")]
       
        public List<TicketDTO> GetAllTickets() => _ticketService.GetAllTickets();

        [HttpGet]
        [Route("Tickets/{id}")]
        
        public TicketDTO GetTicketById([FromRoute] int id) => _ticketService.GetTicketById(id);

        [HttpGet]
        [Route("Tickets/{id}/WithUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Admin)]
        public TicketDTO GetTicketWithUser([FromRoute] int id) => _ticketService.GetTicketByIdWithUser(id);

        [HttpGet]
        [Route("Tickets/{id}/WithPerformance")]
       
        public TicketDTO GetTicketWithPerformance([FromRoute] int id) => _ticketService.GetTicketByIdWithPerformance(id);

        [HttpPost]
        [Route("Tickets")]
      
        public IActionResult AddTicket([FromBody] TicketDTO newTicket)
        {
            if (TryValidateModel(newTicket))
            {
                return Ok(_ticketService.AddNewTicket(newTicket));
            }


            return BadRequest(new { Errors, newTicket });

        }
        #endregion

        #region Invoices
#warning TODO
        #endregion
    }
}