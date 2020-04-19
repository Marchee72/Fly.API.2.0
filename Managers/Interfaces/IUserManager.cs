using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers.Interfaces
{
    public interface IUserManager
    {
        public IQueryable<User> GetUsers();
        public List<Role.Access> GetPermissions(string roleId);
        public void UpdateImg(string userId, byte[] img);
        public byte[] GetImg(string userId);
    }
}
