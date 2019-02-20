using MongoDB.Bson.Serialization.Attributes;

namespace BillingTracker.Models
{
    public class HouseBills
    {
        [BsonElement("Electicity")]
        public decimal Electicity { get; set; }
        [BsonElement("Water")]
        public decimal Water { get; set; }
        [BsonElement("Internet")]
        public decimal Internet { get; set; }
    }
}