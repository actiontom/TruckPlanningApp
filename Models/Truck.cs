using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TruckPlanningApp.Models
{
    public class Truck
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("licensePlate")]
        public string LicensePlate { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("driverId")]
        public string DriverId { get; set; }

        // New attributes
        [BsonElement("maxLoadCapacity")]
        public double MaxLoadCapacity { get; set; } // in kilograms

        [BsonElement("currentLoad")]
        public double CurrentLoad { get; set; } // in kilograms

        [BsonElement("truckType")]
        public string TruckType { get; set; }

        [BsonElement("fuelType")]
        public string FuelType { get; set; }

        [BsonElement("fuelCapacity")]
        public double FuelCapacity { get; set; } // in liters

        [BsonElement("currentFuelLevel")]
        public double CurrentFuelLevel { get; set; } // in liters

        [BsonElement("dimensions")]
        public Dimensions Dimensions { get; set; } // Nested object for dimensions

        [BsonElement("registrationDate")]
        public DateTime RegistrationDate { get; set; }

        [BsonElement("nextMaintenanceDate")]
        public DateTime NextMaintenanceDate { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("odometerReading")]
        public double OdometerReading { get; set; } // in kilometers

        [BsonElement("location")]
        public string Location { get; set; }
    }

    // Nested class for dimensions
    public class Dimensions
    {
        public double Length { get; set; } // in meters
        public double Width { get; set; }  // in meters
        public double Height { get; set; } // in meters
    }
}
