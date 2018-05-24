using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Test")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class TestController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        public TestController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [Route("testAuth")]
        public async Task<string> testAuthenticated()
        {
            return (await GetCurrentUser()).UserName;
        }
        
        private Task<ApplicationUser> GetCurrentUser() => _userManager.GetUserAsync(User);



    }
}

