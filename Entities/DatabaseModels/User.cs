using Entities.Lw;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Entities.DatabaseModels
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Token { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProfilePicture { get; set; }
        public RoleLw Role { get; set; }

    }
}
