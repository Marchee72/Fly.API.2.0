using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repos.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string username, string password);
        IQueryable<User> GetByRole(string role);
    }
}
