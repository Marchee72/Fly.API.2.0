using Entities.DatabaseModels;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Interfaces
{
    public interface IFlayDatabase
    {
        public IMongoDatabase GetMongoConfig();
        public IMongoCollection<User> Users { get; }
        public IMongoCollection<Role> Roles { get; }
        public IMongoCollection<Building> Buildings { get; }
        public IGridFSBucket UsersPicture { get; }

    }
}
