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
using System.Security.Claims;
using System.Threading.Tasks;
using static Entities.DatabaseModels.Role;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("getPermisions")]
        public List<Access> GetPermissions()
        {
            var roleName = User.Claims.First(_ => _.Type == ClaimTypes.Role).Value;
            return _userManager.GetPermissions(roleName);

        }
    }
}
