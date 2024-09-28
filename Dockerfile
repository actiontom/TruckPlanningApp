FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TruckPlanningApp.csproj", "./"]
RUN dotnet restore "TruckPlanningApp.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "TruckPlanningApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TruckPlanningApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TruckPlanningApp.dll"]
