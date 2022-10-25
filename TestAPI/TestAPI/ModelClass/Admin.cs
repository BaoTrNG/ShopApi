using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace TestAPI.ModelClass
{
    public class Admin
    {

        [DataMember]


        public string ID { get; set; }
        [DataMember]
        public string phone { get; set; }
    }
}