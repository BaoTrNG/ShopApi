using MongoDB.Bson.Serialization.Attributes;
namespace TestAPI.ModelClass
{
    public class Items
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Name { get; set; }
        public string Price { get; set; }
        public string Remain { get; set; }

    }
}
