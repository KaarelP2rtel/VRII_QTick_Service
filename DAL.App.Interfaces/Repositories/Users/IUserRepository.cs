using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.Interfaces.Repositories
{
    public interface IUserRepository
    { 
        IEnumerable<ApplicationUser> All();

        ApplicationUser Find(string id);

        void Add(ApplicationUser user, string pass);

        ApplicationUser Update(ApplicationUser user);
        ApplicationUser Update(ApplicationUser user, string oldPass,string newPass);

        void Remove(ApplicationUser user);
        void Remove(string id);
        ApplicationUser FindByName(string username);
    }
}


