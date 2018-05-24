using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface ITicketService
    {
        List<TicketDTO> GetAllTickets();
        TicketDTO GetTicketById(int id);
        TicketDTO GetTicketByIdWithPerformance(int id);
        TicketDTO AddNewTicket(TicketDTO ticket);

    }
}
