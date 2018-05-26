using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;

namespace BL.Interfaces
{
    public interface IApplicationUserService
    {
        List<ApplicationUserDTO> GetAllApplicationUsers();
        ApplicationUserDTO GetApplicationUserById(string id);
        ApplicationUserDTO AddNewApplicationUser(NewUserDTO newUser);
        ApplicationUserDTO GetApplicationUserByName(string userName);
    }
}
