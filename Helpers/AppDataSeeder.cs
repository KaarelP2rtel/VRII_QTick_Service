using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain;
using DAL.App.EF;

namespace WebApp.Helpers
{
    /// <summary>
    /// For Seeders 
    /// </summary>
    public class AppDataSeeder
    {
        /// <summary>
        /// For Seeders initializing in AppDatabase
        /// </summary>
        /// <param name="context">Reads the context</param>
        public static void InitializeAppDatabase(ApplicationDbContext context)
        {
        }

        /// <summary>
        /// Adding user roles
        /// </summary>
        private static readonly string[] Roles = new[]
        {
            "User",
            "Admin"
        };

        /// <summary>
        /// Initialize the Indetity of User
        /// </summary>
        /// <param name="userManager">usermanager width pwd</param>
        /// <param name="roleManager">rolemanager width pwd</param>
        public static void InitializeIdentity(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            foreach (var role in Roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }

            var adminName = "admin@admin.ee";
            var adminPass = "Salakala!23";

            var userName = "user@user.ee";
            var userPass = "Salakala!23";

            if (userManager.FindByNameAsync(adminName).Result == null)
            {
                var admin = new ApplicationUser()
                {
                    UserName = adminName,
                    Email = adminName
                };

                var res = userManager.CreateAsync(admin, adminPass).Result;
                if (res == IdentityResult.Success)
                {
                    foreach (var role in Roles)
                    {
                        userManager.AddToRoleAsync(admin, role).Wait();
                    }
                }
            }

            if (userManager.FindByNameAsync(userName).Result == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName
                };

                var res = userManager.CreateAsync(user, userPass).Result;
                if (res == IdentityResult.Success)
                {


                    userManager.AddToRoleAsync(user, "User").Wait();

                }
            }
        }
    }

}
