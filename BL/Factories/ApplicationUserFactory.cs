using System;
using System.Collections.Generic;
using System.Text;
using BL.DTO;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace BL.Factories
{
    public interface IApplicationUserFactory
    {
        ApplicationUserDTO Transform(ApplicationUser au);
        
        
    }

    public class ApplicationUserFactory : IApplicationUserFactory
    {
        public ApplicationUserDTO Transform(ApplicationUser au)
        {
            if (au == null) return null;
            return new ApplicationUserDTO
            {
                Name = au.Name,
                Registered = au.Registered,
                Active = au.Active
            };
        }

    }
}
