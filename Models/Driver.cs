using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TruckPlanningApp.Models
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("licenseNumber")]
        public string? LicenseNumber { get; set; }

        [BsonElement("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [BsonElement("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [BsonElement("assignedTruckId")]
        public string? AssignedTruckId { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }
    }


}
