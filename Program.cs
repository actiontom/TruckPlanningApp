var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TruckPlanningDatabaseSettings>(
    builder.Configuration.GetSection("TruckPlanningDatabaseSettings"));

builder.Services.AddSingleton<TruckService>() ; // Register TruckService
builder.Services.AddControllers(); // Add controllers to the service container

var app = builder.Build();

app.MapControllers();

app.Run();
