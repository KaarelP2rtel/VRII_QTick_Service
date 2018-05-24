using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.App.Interfaces.Repositories;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.EF.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EFUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> All()
        {
            return _userManager.Users.ToList();
        }

        public ApplicationUser Find(string id)
        {
            return _userManager.Users.ToList()
                .SingleOrDefault(au => au.Id == id);
        }

        public async void Add(ApplicationUser user)
        {
            await _userManager.CreateAsync(user);
        }

        public ApplicationUser Update(ApplicationUser user)
        {
           // return await _userManager.UpdateAsync(user);
             throw new NotImplementedException();
        }

        public void Remove(ApplicationUser user)
        {
            throw new NotImplementedException();
            
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
