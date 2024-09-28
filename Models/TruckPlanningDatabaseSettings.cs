namespace TruckPlanningApp.Models
{
    public class TruckPlanningDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string TrucksCollectionName { get; set; } = null!;
    }
}
