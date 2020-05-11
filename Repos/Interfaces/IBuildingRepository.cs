using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repos.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Building Get(string streetName, string streetNumber);
    }
}
