using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BillingTracker.Models
{
    public class UsersModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Phone")]
        public string Phone { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        [BsonElement("Cars")]
        public List<Cars> Cars { get; set; }
        // [BsonElement("House")]
        // public List<HouseBills> Bills { get; set; }
    }
}