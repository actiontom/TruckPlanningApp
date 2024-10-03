using MongoDB.Driver;
using TruckPlanningApp.Models;
using Microsoft.Extensions.Options;

namespace TruckPlanningApp.Services
{
    public class TruckService
    {
        private readonly IMongoCollection<Truck> _trucks;
        private readonly IMongoCollection<Driver> _drivers;

        public TruckService(IOptions<TruckPlanningDatabaseSettings> truckPlanningDatabaseSettings)
        {
            var mongoClient = new MongoClient(truckPlanningDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(truckPlanningDatabaseSettings.Value.DatabaseName);
            _trucks = mongoDatabase.GetCollection<Truck>(truckPlanningDatabaseSettings.Value.TrucksCollectionName);
            _drivers = mongoDatabase.GetCollection<Driver>(truckPlanningDatabaseSettings.Value.DriversCollectionName);
        }

        // Get all trucks
        public List<Truck> Get() => _trucks.Find(truck => true).ToList();

        // Get a truck by ID
        public Truck Get(string id) => _trucks.Find(truck => truck.Id == id).FirstOrDefault();

        // Create a new truck~
        public Truck Create(Truck truck)
        {
            _trucks.InsertOne(truck);
            return truck;
        }

        // Update an existing truck
        public void Update(string id, Truck truckIn)
        {
            // Ensure only the specified truck is updated
            _trucks.ReplaceOne(truck => truck.Id == id, truckIn);
        }

        // Remove a truck by ID
        public void Remove(string id)
        {
            _trucks.DeleteOne(truck => truck.Id == id);
        }
        // In TruckService.cs
    public List<Truck> GetAvailableTrucks() => _trucks.Find(truck => truck.Status == "Available").ToList();

    public void AssignDriverToTruck(string truckId, string driverId)
        {
            var truck = _trucks.Find(t => t.Id == truckId).FirstOrDefault();
            var driver = _drivers.Find(d => d.Id == driverId).FirstOrDefault();

            if (truck == null)
            {
                throw new Exception($"Truck with ID {truckId} not found.");
            }

            if (driver == null)
            {
                throw new Exception($"Driver with ID {driverId} not found.");
            }

            if (truck.Status != "Available")
            {
                throw new Exception($"Truck with ID {truckId} is not available.");
            }

            if (driver.Status != "Available")
            {
                throw new Exception($"Driver with ID {driverId} is not available.");
            }

            // Proceed with assignment
            truck.AssignedDriverId = driverId;
            truck.Status = "Assigned";
            _trucks.ReplaceOne(t => t.Id == truckId, truck);

            driver.AssignedTruckId = truckId;
            driver.Status = "Assigned";
            _drivers.ReplaceOne(d => d.Id == driverId, driver);
        }



    }
}
