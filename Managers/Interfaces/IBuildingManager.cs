using Entities.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers.Interfaces
{
    public interface IBuildingManager
    {
        Building GetBuilding(string buildingId);
        IQueryable<Building> GetBuildings();

    }
}

