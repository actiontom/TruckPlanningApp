using TruckPlanningApp.Models;
using TruckPlanningApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.Configure<TruckPlanningDatabaseSettings>(
    builder.Configuration.GetSection("TruckPlanningDatabaseSettings"));

builder.Services.AddSingleton<TruckService>();
builder.Services.AddSingleton<DriverService>(); // Register DriverService
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

// Bind to all network interfaces
app.Urls.Add("http://0.0.0.0:80");

app.Run();
