using Database;
using System;
using Entities.DatabaseModels;
using System.Linq;
using MongoDB.Driver;
using Database.Interfaces;
using System.Collections.Generic;
using Repos.Interfaces;
using MongoDB.Driver.Linq;

namespace Repos
{
    public class BuildingsRepo: IBuildingRepository
    {
        private readonly IMongoCollection<Building> _buildings;

        public BuildingsRepo(IFlayDatabase database)
        {
            _buildings = database.Buildings;
        }

        public IQueryable<Building> Get() =>
            _buildings.AsQueryable();
        public Building Get(string id) =>
            _buildings.AsQueryable().FirstOrDefault(building => building.Id == id);
        public Building Get(string streetname, string streetNumber) =>
            _buildings.AsQueryable().SingleOrDefault(x => x.StreetName == streetname && x.StreetNumber == streetNumber);
        public Building Create(Building building)
        {
            _buildings.InsertOne(building);
            return building;
        }
        public void Update(string id, Building buildingIn) =>
            _buildings.ReplaceOne(building => building.Id == id, buildingIn);
        public void Remove(Building buildingIn) =>
            _buildings.DeleteOne(building => building.Id == buildingIn.Id);
        public void Remove(string id) =>
            _buildings.DeleteOne(building => building.Id == id);
    }
}
