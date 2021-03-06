﻿using Entities.DatabaseModels;
using Entities.Lw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers.Interfaces
{
    public interface IUserManager
    {
        void SaveUser(User user);
        User GetUser(string userId);
        IQueryable<User> GetUsers();
        List<Role.Access> GetPermissions(string roleId);
        void UpdateImg(string userId, byte[] img);
        byte[] GetImg(string userId);
        void RemovePictureByName(string filename);
        IEnumerable<RoleLw> GetRoles();
        IEnumerable<UserLw> GetAdmins(string userId);
    }
}
