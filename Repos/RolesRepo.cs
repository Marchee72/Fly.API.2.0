using Database.Interfaces;
using Entities.DatabaseModels;
using MongoDB.Driver;
using Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repos
{
    public class RolesRepo : IRoleRepository
    {
        private readonly IMongoCollection<Role> _roles;
        public RolesRepo(IFlayDatabase database)
        {
            _roles = database.Roles;
        }
        public Role Create(Role role)
        {
            _roles.InsertOne(role);
            return role;
        }
        public IQueryable<Role> Get() =>
            _roles.AsQueryable();
        public Role Get(string id) =>
            _roles.AsQueryable().FirstOrDefault(role => role.Id == id);
        public Role GetByName(string name) =>
            _roles.AsQueryable().FirstOrDefault(role => role.Name == name);
        public void Remove(Role roleIn) =>
            _roles.DeleteOne(role => role.Id == roleIn.Id);
        public void Remove(string id) =>
            _roles.DeleteOne(role => role.Id == id);
        public void Update(string id, Role roleIn) =>
            _roles.ReplaceOne(user => user.Id == id, roleIn);
    }
}
