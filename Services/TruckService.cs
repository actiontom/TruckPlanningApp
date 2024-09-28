using TruckPlanningApp.Models;
using MongoDB.Driver;

namespace TruckPlanningApp.Services
{
    public class TruckService
    {
        private readonly IMongoCollection<Truck> _trucks;

        public TruckService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TruckPlanningAppDb"));
            var database = client.GetDatabase("TruckPlanningDb");
            _trucks = database.GetCollection<Truck>("Trucks");
        }

        public List<Truck> Get() => _trucks.Find(truck => true).ToList();

        public Truck Get(string id) => _trucks.Find(truck => truck.Id == id).FirstOrDefault();

        public Truck Create(Truck truck)
        {
            _trucks.InsertOne(truck);
            return truck;
        }

        public void Update(string id, Truck truckIn) => _trucks.ReplaceOne(truck => truck.Id == id, truckIn);

        public void Remove(string id) => _trucks.DeleteOne(truck => truck.Id == id);
    }
}
