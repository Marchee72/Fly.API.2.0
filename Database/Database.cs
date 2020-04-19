using Database.Interfaces;
using Entities.DatabaseModels;
using System.Collections.Generic;
using MongoDB.Driver;
using System;
using System.Linq;
using MongoDB.Driver.Linq;
using MongoDB.Driver.GridFS;

namespace Database
{
    public class Database : IFlayDatabase
    {
        private IMongoDatabase _database;
        public IMongoCollection<User> Users { get; private set; }
        public IMongoCollection<Role> Roles { get; private set; }
        public IGridFSBucket UsersPicture { get; private set; }
        public Database()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("Flay");
            Users = _database.GetCollection<User>("users");
            Roles = _database.GetCollection<Role>("roles");

            UsersPicture = new GridFSBucket(_database, new GridFSBucketOptions
            {
                BucketName = "usersPicture",
                ChunkSizeBytes = 1048576, // 1MB
                WriteConcern = WriteConcern.WMajority,
                ReadPreference = ReadPreference.Secondary
            });

        }

        public IMongoDatabase GetMongoConfig() => _database;

    }
}
