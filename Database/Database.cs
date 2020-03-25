using Database.Interfaces;
using Entities.DatabaseModels;
using System.Collections.Generic;
using MongoDB.Driver;
using System;
using System.Linq;
using MongoDB.Driver.Linq;

namespace Database
{
    public class Database : IFlayDatabase
    {
        private IMongoDatabase _database;
        public IMongoCollection<User> Users { get; private set; }
        public Database()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("Flay");
            Users = _database.GetCollection<User>("users");
        }

        public IMongoDatabase GetMongoConfig() => _database;

    }
}
