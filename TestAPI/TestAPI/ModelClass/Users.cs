﻿using MongoDB.Bson.Serialization.Attributes;

namespace TestAPI.ModelClass
{
    public class Users
    {
        [BsonId]
        public string Id { get; set; }
        public string Pass { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; } = null;
        public string Status { get; set; } = "ok";

    }

}
