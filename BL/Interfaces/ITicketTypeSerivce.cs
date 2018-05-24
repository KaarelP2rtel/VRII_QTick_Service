﻿using BL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Interfaces
{
    public interface ITicketTypeSerivce
    {
        List<TicketTypeDTO> GetAllTicketTypes();
        TicketTypeDTO GetTicketTypeById(int id);
        TicketTypeDTO AddNewTicketType(TicketTypeDTO newTicketType);
    }
}