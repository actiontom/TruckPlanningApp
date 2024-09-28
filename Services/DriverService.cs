using MongoDB.Bson;
using MongoDB.Driver;
using TruckPlanningApp.Models;
using Microsoft.Extensions.Options;

namespace TruckPlanningApp.Services
{
    public class DriverService
    {
        private readonly IMongoCollection<Driver> _drivers;

        public DriverService(IOptions<TruckPlanningDatabaseSettings> truckPlanningDatabaseSettings)
        {
            var mongoClient = new MongoClient(truckPlanningDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(truckPlanningDatabaseSettings.Value.DatabaseName);
            _drivers = mongoDatabase.GetCollection<Driver>("Drivers");
        }

        public List<Driver> Get() => _drivers.Find(driver => true).ToList();

        public Driver Get(string id) => _drivers.Find(driver => driver.Id == id).FirstOrDefault();

        public Driver Create(Driver driver)
        {
            _drivers.InsertOne(driver);
            return driver;
        }

        public void Update(string id, Driver driverIn)
        {
            var objectId = new ObjectId(id);
            _drivers.ReplaceOne(driver => driver.Id == objectId.ToString(), driverIn);
        }

        public void Remove(string id)
        {
            var objectId = new ObjectId(id);
            _drivers.DeleteOne(driver => driver.Id == objectId.ToString());
        }
    }
}
