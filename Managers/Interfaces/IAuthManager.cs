using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Interfaces
{
    public interface IAuthManager
    {
        public User Authenticate(string username, string password);
    }
}
