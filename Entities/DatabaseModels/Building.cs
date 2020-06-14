using Entities.Interfaces;
using Entities.Lw;
using Entities.Others;
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
        public bool Bis { get; set; }
        public List<Floor> Floors { get; set; }
        public UserLw Administrator { get; set; }
    }
}
