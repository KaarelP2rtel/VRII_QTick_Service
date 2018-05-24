using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace BL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserFactory _applicationUserFactory;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, IApplicationUserFactory applicationUserFactory)
        {
            _userManager = userManager;
            _applicationUserFactory = applicationUserFactory;
        }

        public List<ApplicationUserDTO> GetAllApplicationUsers()
        {
            throw new NotImplementedException();
        }

        public ApplicationUserDTO GetApplicationUserById(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUserDTO AddNewApplicationUser(ApplicationUserDTO newApplicationUser)
        {
            throw new NotImplementedException();
        }
    }
}



