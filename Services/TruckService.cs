using MongoDB.Driver;
using TruckPlanningApp.Models;
using Microsoft.Extensions.Options;

namespace TruckPlanningApp.Services
{
    public class TruckService
    {
        private readonly IMongoCollection<Truck> _trucks;

        public TruckService(IOptions<TruckPlanningDatabaseSettings> truckPlanningDatabaseSettings)
        {
            var mongoClient = new MongoClient(truckPlanningDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(truckPlanningDatabaseSettings.Value.DatabaseName);
            _trucks = mongoDatabase.GetCollection<Truck>(truckPlanningDatabaseSettings.Value.TrucksCollectionName);
        }

        // Get all trucks
        public List<Truck> Get() => _trucks.Find(truck => true).ToList();

        // Get a truck by ID
        public Truck Get(string id) => _trucks.Find(truck => truck.Id == id).FirstOrDefault();

        // Create a new truck
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
    }
}
