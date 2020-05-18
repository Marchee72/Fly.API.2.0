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
    public class BuildingManager : IBuildingManager
    {
        private readonly IBuildingRepository _buildings;


        public BuildingManager(IBuildingRepository buildings)
        {
            _buildings = buildings;

        }

        public Building GetBuilding(string buildingId)
        {
            return _buildings.Get(buildingId);
        }


        public IQueryable<Building> GetBuildings()
        {
            return _buildings.Get();
        }

        public IQueryable<Building> GetBuildings(string userId)
        {
            return _buildings.GetAll(userId);
        }

    }
}
