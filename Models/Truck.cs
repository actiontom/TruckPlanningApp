using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TruckPlanningApp.Models
{
    public class Truck
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("licensePlate")]
        public string? LicensePlate { get; set; }

        [BsonElement("color")]
        public string? Color { get; set; }

        // New field for assigned driver ID
        [BsonElement("assignedDriverId")]
        public string? AssignedDriverId { get; set; }

        [BsonElement("maxLoadCapacity")]
        public double? MaxLoadCapacity { get; set; } // in kilograms

        [BsonElement("currentLoad")]
        public double? CurrentLoad { get; set; } // in kilograms

        [BsonElement("truckType")]
        public string? TruckType { get; set; }

        [BsonElement("fuelType")]
        public string? FuelType { get; set; }

        [BsonElement("fuelCapacity")]
        public double? FuelCapacity { get; set; } // in liters

        [BsonElement("currentFuelLevel")]
        public double? CurrentFuelLevel { get; set; } // in liters

        [BsonElement("dimensions")]
        public Dimensions? Dimensions { get; set; }

        [BsonElement("registrationDate")]
        public DateTime? RegistrationDate { get; set; }

        [BsonElement("nextMaintenanceDate")]
        public DateTime? NextMaintenanceDate { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; } // e.g., "Available", "Assigned", etc.

        [BsonElement("odometerReading")]
        public double? OdometerReading { get; set; } // in kilometers

        [BsonElement("location")]
        public string? Location { get; set; }
    }

    public class Dimensions
    {
        [BsonElement("length")]
        public double? Length { get; set; }

        [BsonElement("width")]
        public double? Width { get; set; }

        [BsonElement("height")]
        public double? Height { get; set; }
    }
}
