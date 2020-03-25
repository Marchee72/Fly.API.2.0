using Entities.DatabaseModels;
using Entities.ViewModels;
using Managers;
using Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IQueryable<User> SayHi()
        {
            return _userManager.GetUsers();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public JsonResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userManager.Authenticate(model.Username, model.Password);

            if (user == null)
                return new JsonResult(new { message = "Username or password is incorrect" });

            return new JsonResult(user);
        }

        [AllowAnonymous]
        [HttpPost("authenticate2")]
        public JsonResult Authenticate(string username)
        {
            var password = "admin";
            var user = _userManager.Authenticate(username, password);

            if (user == null)
                return new JsonResult(new { message = "Username or password is incorrect" });

            return new JsonResult(user);
        }
    }
}
