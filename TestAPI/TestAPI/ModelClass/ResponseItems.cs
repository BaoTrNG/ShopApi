using MongoDB.Bson.Serialization.Attributes;
namespace TestAPI.ModelClass
{
    public class ResponseItems
    {
        public string code { get; set; }
        public List<string> Id { get; set; }

    }
}
