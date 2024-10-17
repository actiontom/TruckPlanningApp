using Microsoft.OpenApi.Models;
using TruckPlanningApp.Models; 
using TruckPlanningApp.Services; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.Configure<TruckPlanningDatabaseSettings>(
    builder.Configuration.GetSection("TruckPlanningDatabaseSettings"));

builder.Services.AddSingleton<TruckService>();
builder.Services.AddSingleton<DriverService>(); 
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Truck Planning API",
        Version = "v1",
        Description = "API for Truck and Driver management in TruckPlanningApp"
    });
});

var app = builder.Build();

// Disable HTTPS redirection when running in Docker
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowAll");

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Truck Planning API v1");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

// Bind to all network interfaces
app.Urls.Add("http://0.0.0.0:80");

app.Run();
