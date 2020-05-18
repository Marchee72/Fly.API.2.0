using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Lw
{
    public class UserLw
    {
        public UserLw() { }
        public UserLw(string id, string username)
        {
            Id = id;
            UserName = username;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
