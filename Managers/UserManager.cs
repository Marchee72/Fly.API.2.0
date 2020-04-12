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

        public UserManager(IUserRepository users, IRoleRepository roles)
        {
            _users = users;
            _roles = roles;
        }

        public List<Role.Access> GetPermissions(string roleId)
        {
            return _roles.GetByName(roleId).Accesses;
        }

        public IQueryable<User> GetUsers()
        {
            return _users.Get();
        }

    }
}
