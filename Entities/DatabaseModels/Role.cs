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
        public List<Access> Accesses { get; set; }

        public class Access
        {
            public Access(){}
            public Access(Others.Permissions.Access name, string link, string icon)
            {
                Name = name.ToString();
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
