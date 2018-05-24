using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;

namespace BL.Interfaces
{
    public interface IApplicationUserService
    {
        List<ApplicationUserDTO> GetAllApplicationUsers();
        ApplicationUserDTO GetApplicationUserById(int id);
        ApplicationUserDTO AddNewApplicationUser(ApplicationUserDTO newApplicationUser);
    }
}
