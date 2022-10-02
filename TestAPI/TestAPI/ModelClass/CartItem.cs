using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace TestAPI.ModelClass
{


    public class CartItem
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public int amount { get; set; }

        [DataMember]
        public double price { get; set; }
    }
}
