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

        public ApplicationUserDTO AddNewApplicationUser(NewUserDTO newUser)
        {

            _uow.Users.Add(new ApplicationUser
            {
                UserName = newUser.UserName,
                Email = newUser.UserName,
                Name = newUser.Name,
                Registered=DateTime.Now
                
            },newUser.Password);
            return _applicationUserFactory.Transform(_uow.Users.FindByName(newUser.UserName));
        }

        public List<ApplicationUserDTO> GetAllApplicationUsers()
        {
            return _uow.Users.All()
                .Select(u => _applicationUserFactory.Transform(u))
                .ToList();
        }

        public ApplicationUserDTO GetApplicationUserById(string id)
        {
            return _applicationUserFactory.Transform(_uow.Users.Find(id));
        }

        public ApplicationUserDTO GetApplicationUserByName(string userName)
        {
            return _applicationUserFactory.Transform(_uow.Users.FindByName(userName));
        }
    }
}



