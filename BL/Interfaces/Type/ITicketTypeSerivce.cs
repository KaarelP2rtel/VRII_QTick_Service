using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface ITicketTypeService
    {
        List<TicketTypeDTO> GetAllTicketTypes();
        TicketTypeDTO GetTicketTypeById(int id);
        TicketTypeDTO AddNewTicketType(TicketTypeDTO newTicketType);
        bool DeleteTicketType(int id);
        TicketTypeDTO UpdateTicketType(TicketTypeDTO ticketType);
    }
}
