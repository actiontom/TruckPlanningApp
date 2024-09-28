using MongoDB.Bson;
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

        public List<Truck> Get() => _trucks.Find(truck => true).ToList();

        public Truck Get(string id) => _trucks.Find(truck => truck.Id == id).FirstOrDefault();

        public Truck Create(Truck truck)
        {
            _trucks.InsertOne(truck);
            return truck;
        }

        public void Update(string id, Truck truckIn)
        {
            var objectId = new ObjectId(id);
            _trucks.ReplaceOne(truck => truck.Id == objectId.ToString(), truckIn);
        }

        public void Remove(string id)
        {
            var objectId = new ObjectId(id);
            _trucks.DeleteOne(truck => truck.Id == objectId.ToString());
        }
    }
}
