﻿using MongoDB.Bson.Serialization.Attributes;

namespace TestAPI.ModelClass
{
    public class Users
    {
        [BsonId]
        //   [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Pass { get; set; }
        public string Type { get; set; }
        public string Email { get; set; } = null;


    }

}