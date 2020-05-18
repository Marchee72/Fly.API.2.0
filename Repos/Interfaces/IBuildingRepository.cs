using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repos.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Building Get(string streetName, string streetNumber);
        IQueryable<Building> GetAll(string userId);

    }
}
