using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace TestAPI.ModelClass
{

    public class Carts
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        public string buyer { get; set; }

        public double total { get; set; }
        [BsonElement("items")]
        public List<CartItem> items { get; set; }

    }

}
