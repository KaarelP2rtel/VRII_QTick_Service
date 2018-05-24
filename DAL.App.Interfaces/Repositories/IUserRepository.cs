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

        void Add(ApplicationUser user);

        ApplicationUser Update(ApplicationUser user);

        void Remove(ApplicationUser user);
        void Remove(string id);

        bool Exists(ApplicationUser user);
    }
}


