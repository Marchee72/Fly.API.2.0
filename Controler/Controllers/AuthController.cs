using Entities.DatabaseModels;
using Entities.ViewModels;
using Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager userManager)
        {
            _authManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public User Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _authManager.Authenticate(model.Username, model.Password);
            return user ?? new User();
        }
    }
}
