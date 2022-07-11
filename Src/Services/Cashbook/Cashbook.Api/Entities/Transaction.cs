using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cashbook.Api.Entities
{
    public class Transaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Tran_Id { get; set; }
        public DateTime Tran_Date { get; set; }
        public string? Tran_Type { get; set; }
        public string? Tran_ParticularId { get; set; }
        public decimal? Tran_Amount { get; set; }
        public string? Tran_Remarks { get; set; }
        public string? Tran_UserId { get; set; }
        public DateTime? Tran_EntryDate { get; set; }

    }
}
