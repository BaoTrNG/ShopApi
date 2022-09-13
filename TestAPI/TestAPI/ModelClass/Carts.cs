using MongoDB.Bson.Serialization.Attributes;

namespace TestAPI.ModelClass
{
    public class Carts
    {
        [BsonId]
        //   [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Buyer { get; set; }
        public string Date { get; set; }
        public string Email { get; set; } = null;


    }

}
