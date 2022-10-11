﻿using MongoDB.Bson.Serialization.Attributes;
namespace TestAPI.ModelClass
{
    public class Items
    {
        [BsonId]
        public string Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Remain { get; set; }
        public string Image { get; set; }

        public string url { get; set; }

    }
}
