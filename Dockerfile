# Use the official ASP.NET Core runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj and restore the dependencies
COPY ["TruckPlanningApp.csproj", "./"]
RUN dotnet restore "TruckPlanningApp.csproj"

# Copy the rest of the application source code and build it
COPY . .
WORKDIR "/src"
RUN dotnet build "TruckPlanningApp.csproj" -c Release -o /app/build

# Publish the application to a folder
FROM build AS publish
RUN dotnet publish "TruckPlanningApp.csproj" -c Release -o /app/publish

# Use the runtime base image and copy the publish folder to the final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment variable for ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT=Docker

# Specify the entry point to run the application
ENTRYPOINT ["dotnet", "TruckPlanningApp.dll"]
