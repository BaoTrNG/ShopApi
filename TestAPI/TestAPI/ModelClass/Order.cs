using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace TestAPI.ModelClass
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string buyer { get; set; }
        public string status { get; set; }
        public string payment { get; set; }
        public string address { get; set; }
        public string date { get; set; }
        public double total { get; set; }
        [BsonElement("items")]
        public List<CartItem> items { get; set; }
    }
}
