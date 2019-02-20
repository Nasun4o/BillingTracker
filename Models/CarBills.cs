using MongoDB.Bson.Serialization.Attributes;

namespace BillingTracker.Models
{
    public class CarBills
    {
        [BsonElement("Car_annual_tax")]
        public decimal CarAnnualTax { get; set; }
        [BsonElement("Car_roll_tax")]
        public decimal CarRollTax { get; set; }
        [BsonElement("Car_annual_technical_check")]
        public decimal CarAnnualTechnicalCheck { get; set; }
    }
}