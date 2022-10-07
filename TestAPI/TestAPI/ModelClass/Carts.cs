using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace TestAPI.ModelClass
{

    public class Carts
    {
        [BsonId]
        public string Id { get; set; }


        public double total { get; set; }
        [BsonElement("items")]
        public List<CartItem> items { get; set; }

    }

}
