using MongoDB.Bson.Serialization.Attributes;

namespace BillingTracker.Models
{
    public class Cars
    {
        [BsonElement("Model")]
        public string Model { get; set; }
        [BsonElement("Make")]
        public string Make { get; set; }
        // [BsonElement("Car_bills")]
        // public CarBills Bills { get; set; }
    }
}