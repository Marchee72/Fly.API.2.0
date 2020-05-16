using Entities.DatabaseModels;
using Entities.Lw;
using Entities.Others;
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
using System.Text;
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

        [Authorize()]
        [HttpGet("getPermisions")]
        public List<Access> GetPermissions()
        {
            var roleName = User.Claims.First(_ => _.Type == ClaimTypes.Role).Value;
            return _userManager.GetPermissions(roleName);

        }
        [Authorize()]
        [HttpPost("updateImage")]
        public void UpdateImage([FromBody] string img)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(img);
            var userId = User.Claims.First(_ => _.Type == ClaimTypes.Name).Value;
            _userManager.UpdateImg(userId, bytes);
        }
        [Authorize()]
        [HttpGet("getProfilePicture")]
        public JsonResult GetProfilePicture()
        {
            var userId = User.Claims.First(_ => _.Type == ClaimTypes.Name).Value;
            var bytes = _userManager.GetImg(userId);
            return bytes != null ? new JsonResult(Encoding.UTF8.GetString(bytes)) : new JsonResult(default);
        }
        [Authorize()]
        [HttpGet("removeProfilePicture")]
        public void RemoveProfilePicture()
        {
            var userId = User.Claims.First(_ => _.Type == ClaimTypes.Name).Value;
            _userManager.RemovePictureByName(userId);
        }
        [Authorize()]
        [HttpGet("getUser")]
        public User GetUser()
        {
            var userId = User.Claims.First(_ => _.Type == ClaimTypes.Name).Value;
            return _userManager.GetUser(userId);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("getAllUsers")]
        public List<User> GetAll()
        {
            return _userManager.GetUsers().ToList();
        }
        [Authorize()]
        [HttpGet("getRoles")]
        public IEnumerable<RoleLw> GetRoles()
        {
            return _userManager.GetRoles();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("save")]
        public void SaveUser([FromBody] User user)
        {
            _userManager.SaveUser(user);
        }
    }
}
