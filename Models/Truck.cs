using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TruckPlanningApp.Models
{
    public class Truck
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("LicensePlate")]
        public string LicensePlate { get; set; }

        [BsonElement("Color")]
        public string Color { get; set; }

        [BsonElement("DriverId")]
        public string DriverId { get; set; } // Reference to Driver
    }
}
