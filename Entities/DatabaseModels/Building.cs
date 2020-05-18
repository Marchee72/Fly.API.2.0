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
    public class Building
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BuildingName { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floors { get; set; }

        public UserLw Administrator { get; set; }

    }
}
