TruckPlanningApp Overview

The TruckPlanningApp is a C# application built with ASP.NET Core and MongoDB. It serves as the backend for a truck and driver management system, providing APIs to manage trucks, drivers, and their assignments.

Features
Create, update, and delete trucks and drivers.
Assign drivers to trucks based on availability.
Track truck details, including license plate, capacity, fuel level, status, etc.
Built using ASP.NET Core, MongoDB, and Docker for containerization.
Prerequisites
.NET 6 SDK
MongoDB (or use Docker to spin up a MongoDB container)
Docker (optional for containerization)
A code editor, such as Visual Studio Code or Visual Studio
Getting Started
1. Clone the Repository
bash
Copy code
git clone https://github.com/your-username/TruckPlanningApp.git
cd TruckPlanningApp
2. Set Up MongoDB
You can run MongoDB using Docker:

bash
Copy code
docker run -d -p 27017:27017 --name mongodb mongo
Or install MongoDB locally by following the official instructions.

3. Update appsettings.json
In the appsettings.json file, configure the MongoDB connection settings:

json
Copy code
{
  "TruckPlanningDatabaseSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "TruckPlanningDB",
    "TrucksCollectionName": "Trucks",
    "DriversCollectionName": "Drivers"
  }
}
4. Run the Application
You can run the application using the .NET CLI:

bash
Copy code
dotnet run
Or, using Docker:

bash
Copy code
docker-compose up --build
5. Access the API
The API will be available at http://localhost:8080. You can use tools like Insomnia or Postman to test the endpoints.

API Endpoints
Here are some of the key endpoints:

Trucks

GET /api/trucks - Retrieve all trucks.
POST /api/trucks - Create a new truck.
PUT /api/trucks/{id} - Update an existing truck.
DELETE /api/trucks/{id} - Delete a truck.
POST /api/trucks/{id}/assign-driver/{driverId} - Assign a driver to a truck.
Drivers

GET /api/drivers - Retrieve all drivers.
POST /api/drivers - Create a new driver.
PUT /api/drivers/{id} - Update an existing driver.
DELETE /api/drivers/{id} - Delete a driver.
6. Additional Commands
Build the Project: dotnet build
Run Tests: dotnet test
Docker
To build and run the application with Docker:

Make sure Docker is running on your system.
Run the application using:
bash
Copy code
docker-compose up --build
Contributing
If you would like to contribute, please fork the repository and use a feature branch. Pull requests are warmly welcome.

License
This project is licensed under the MIT License.
