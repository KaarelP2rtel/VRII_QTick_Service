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
            return _userManager.Users
                .SingleOrDefault(au => au.Id == id);
        }

        public  void Add(ApplicationUser user,string pass)
        {
            var res = _userManager.CreateAsync(user, pass).Result;
            if (res == IdentityResult.Success)
            {
                _userManager.AddToRoleAsync(user, Roles.User).Wait();
            }
        }

        public ApplicationUser Update(ApplicationUser user)
        {
          
            _userManager.UpdateAsync(user);
            return Find(user.Id);
        }

        public void Remove(ApplicationUser user)
        {
            _userManager.DeleteAsync(user);

        }

        public void Remove(string id)
        {
            var user = Find(id);
            Remove(user);
        }

        public ApplicationUser Update(ApplicationUser user, string oldPass, string newPass)
        {
            _userManager.UpdateAsync(user);
            _userManager.ChangePasswordAsync(user, oldPass, newPass);
            return Find(user.Id);
        }

        public ApplicationUser FindByName(string username)
        {
            return _userManager.Users
                .Where(u => u.UserName == username)
                .SingleOrDefault();
        }
    }
}
