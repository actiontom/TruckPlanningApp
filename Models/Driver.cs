using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TruckPlanningApp.Models
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("LicenseNumber")]
        public string LicenseNumber { get; set; }
    }
}
