using Entities.DatabaseModels;
using Helpers;
using Managers.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repos;
using Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _users;
        private readonly IRoleRepository _roles;
        private readonly IPictureRepository _pictures;

        public UserManager(IUserRepository users, IRoleRepository roles, IPictureRepository pictures)
        {
            _users = users;
            _roles = roles;
            _pictures = pictures;
        }

        public User GetUser(string userId)
        {
            return _users.Get(userId).WithoutPassword();
        }

        public List<Role.Access> GetPermissions(string roleId)
        {
            return _roles.GetByName(roleId).Accesses;
        }

        public IQueryable<User> GetUsers()
        {
            return _users.Get();
        }

        public void UpdateImg(string userId, byte[] img)
        {
            _pictures.UpdateOrInsertFromBytes(userId, img);
        }
        
        public byte[] GetImg(string userId)
        {
            return _pictures.DownloadAsBytes(userId);
        }
        public void RemovePictureByName(string filename)
        {
            _pictures.RemoveByName(filename);
        }
    }
}
