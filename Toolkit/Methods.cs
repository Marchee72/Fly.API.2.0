using Database.Interfaces;
using Entities.DatabaseModels;
using Entities.Others;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            CreateRoles();
            var admin = new User() { 
            Username= "admin",
            Password= "admin"
            };
            var role = roleCollection.AsQueryable().FirstOrDefault(_ => _.Name == Permissions.Roles.Admin.ToString());
            admin.Role = role.ToLw();
            userCollection.InsertOne(admin);
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
                Name = Permissions.Roles.Admin,
                AccessList = new List<Role.Access>()
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
        public static void CreateBuilding()
        {
            var _database = ConnectToDatabase();
            var BuildingCollections = _database.GetCollection<Building>("buildings");
            Console.WriteLine("Nombre edidicio, Nombre calle, Num calle, Cant Dptos");
            var building = new Building()
            {
                BuildingName = Console.ReadLine(),
                StreetName = Console.ReadLine(),
                StreetNumber = Console.ReadLine(),
                Floors = Console.ReadLine()

            };
            BuildingCollections.InsertOne(building);
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
