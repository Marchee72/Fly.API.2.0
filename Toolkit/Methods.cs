using Database.Interfaces;
using Entities.DatabaseModels;
using Entities.Others;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var roleCollection = _database.GetCollection<Role>("roles");

            var admin = userCollection.AsQueryable().Where(_ => _.Username == "admin").SingleOrDefault();
            var role = roleCollection.AsQueryable().FirstOrDefault(_ => _.Name == Permissions.Roles.Admin.ToString());
            admin.Role = role.ToLw();
            userCollection.ReplaceOne(user => user.Id == admin.Id, admin);
            Console.WriteLine("User updated!.");
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }

        public static void CreateRoles()
        {
            var _database = ConnectToDatabase();
            var rolesCollection = _database.GetCollection<Role>("roles");
            var role = new Role()
            {
                Name = Permissions.Roles.Admin.ToString(),
                Accesses = new List<Role.Access>()
                {
                    new Role.Access(Permissions.Access.Edificios, "/edifices", "mdi-office-building"),
                    new Role.Access(Permissions.Access.Dashboard, "/dashboard", "mdi-view-dashboard"),
                    new Role.Access(Permissions.Access.Usuarios, "/users", "mdi-account-multiple"),
                }
            };
            rolesCollection.InsertOne(role);
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
