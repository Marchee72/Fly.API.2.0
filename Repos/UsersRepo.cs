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
    public class UsersRepo : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UsersRepo(IFlayDatabase database)
        {
            _users = database.Users;
        }

        public IQueryable<User> Get() => 
            _users.AsQueryable();
        public User Get(string id) => 
            _users.AsQueryable().FirstOrDefault(user => user.Id == id);
        public User Get(string username, string password) => 
            _users.AsQueryable().SingleOrDefault(x => x.Username == username && x.Password == password);
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }
        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);
        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);
        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}
