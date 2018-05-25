using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.DTO;
using BL.Factories;
using BL.Interfaces;
using DAL.App.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace BL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IAppUnitOfWork _uow;
        private readonly IApplicationUserFactory _applicationUserFactory;

        public ApplicationUserService(IAppUnitOfWork uow, IApplicationUserFactory applicationUserFactory)
        {
            _uow = uow;
            _applicationUserFactory = applicationUserFactory;
        }

        public List<ApplicationUserDTO> GetAllApplicationUsers()
        {
            return _uow.Users.All()
                .Select(u => _applicationUserFactory.Transform(u))
                .ToList();
        }

        public ApplicationUserDTO GetApplicationUserById(string id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUserDTO AddNewApplicationUser(ApplicationUserDTO newApplicationUser)
        {
            throw new NotImplementedException();
        }
    }
}



