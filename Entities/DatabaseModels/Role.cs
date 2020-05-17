using Entities.Lw;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DatabaseModels
{
    public class Role
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Access> AccessList { get; set; }

        public class Access
        {
            public Access(){}
            public Access(string name, string link, string icon)
            {
                Name = name;
                Link = link;
                Icon = icon;
            }
            public string Name { get; private set; }
            public string Link { get; private set; }
            public string Icon { get; private set; }
        }

        public RoleLw ToLw()
        {
            return new RoleLw(Id, Name);
        }

    }
}
