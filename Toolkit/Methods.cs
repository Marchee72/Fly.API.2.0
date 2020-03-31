using Database.Interfaces;
using Entities.DatabaseModels;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Toolkit
{
    public static class Methods
    {
        private static IMongoDatabase ConnectToDatabase()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            return client.GetDatabase("Flay");

        }
        public static void UpdateUser()
        {
            var _database = ConnectToDatabase();
            Console.WriteLine("Update user?");
            Console.ReadKey();

            var userCollection = _database.GetCollection<User>("users");
            var admin = userCollection.AsQueryable().Where(_ => _.Username == "admin").SingleOrDefault();
            admin.Role = "Admin";
            userCollection.ReplaceOne(user => user.Id == admin.Id, admin);
            Console.WriteLine("User updated!.");
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
