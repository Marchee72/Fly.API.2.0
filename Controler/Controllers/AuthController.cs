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
        private IAuthManager _authManager;

        public AuthController(IAuthManager userManager)
        {
            _authManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public JsonResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _authManager.Authenticate(model.Username, model.Password);

            if (user == null)
                return new JsonResult(new User());

            return new JsonResult(user);
        }
    }
}
