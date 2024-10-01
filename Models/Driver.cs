using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TruckPlanningApp.Models
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Nullable string

        [BsonElement("Name")]
        public string? Name { get; set; } // Nullable string

        [BsonElement("LicenseNumber")]
        public string? LicenseNumber { get; set; } // Nullable string

        [BsonElement("PhoneNumber")]
        public string? PhoneNumber { get; set; } // Nullable string

        [BsonElement("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; } // Nullable DateTime

        [BsonElement("AssignedTruckId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? AssignedTruckId { get; set; } // Nullable string (ObjectId reference)
    }

}
