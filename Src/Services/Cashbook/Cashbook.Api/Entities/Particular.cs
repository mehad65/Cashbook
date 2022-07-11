using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cashbook.Api.Entities
{
    public class Particular
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Particular_Id { get; set; }

        [BsonElement("Name")]
        public string Particular_Name { get; set; }
        public string? Particular_Details { get; set; }
    }
}
