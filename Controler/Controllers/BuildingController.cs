using Entities.DatabaseModels;
using Entities.Others;
using Entities.ViewModels;
using Managers;
using Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingManager _buildingManager;

        public BuildingController(IBuildingManager buildingManager)
        {
            _buildingManager = buildingManager;
        }

        [Authorize()]
        [HttpGet("getBuildingInformation")]
        public Building GetBuilding()
        {
            var buildingId = "1";////////VER
            return _buildingManager.GetBuilding(buildingId);
        }

        [Authorize()]
        [HttpGet("getAll")]
        public List<Building> GetAll()
        {
            var userId = User.Claims.First(_ => _.Type == ClaimTypes.Name).Value;
            return _buildingManager.GetBuildings(userId).ToList();
            
        }
    }
}
