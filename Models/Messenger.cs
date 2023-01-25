using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DriversAppApi.Models
{
    public class Messenger
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("SenderName")]
        public string Sender { get; set; } = null!;

        public string Message { get; set; } =null!;
    }
}