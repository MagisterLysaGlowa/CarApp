using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext context;
        public VehicleRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<int> Delete(int vehicleID)
        {
            Vehicle? vehicle = await context.Vehicles.FindAsync(vehicleID);
            if (vehicle == null) return 0;
            context.Vehicles.Remove(vehicle);
            return await context.SaveChangesAsync();
        }

        public async Task<Vehicle> Get(int vehicleID)
        {
            Vehicle? vehicle = await context.Vehicles.FindAsync(vehicleID);
            if (vehicle == null) return null!;
            return vehicle;
        }

        public async Task<List<Vehicle>> GetAll()
        {
            List<Vehicle> vehicles = await context.Vehicles.ToListAsync();
            return vehicles;
        }

        public async Task<Vehicle> Update(Vehicle vehicle, int vehicleID)
        {
            Vehicle? vehicle_db = await context.Vehicles.FindAsync(vehicleID)!;
            if (vehicle_db == null)
            {
                throw new Exception($"Failed to update vehicle with vehicle id = {vehicleID}");
            }

            vehicle_db.Model = vehicle.Model;
            vehicle_db.Year = vehicle.Year;
            vehicle_db.Color = vehicle.Color;
            vehicle_db.GearboxID = vehicle.GearboxID;
            vehicle_db.Mileage = vehicle.Mileage;
            vehicle_db.EngineID = vehicle.EngineID;
            vehicle_db.SeatingCapacity = vehicle.SeatingCapacity;
            vehicle_db.BodyType = vehicle.BodyType;
            vehicle_db.VIN = vehicle.VIN;
            vehicle_db.Price = vehicle.Price;
            vehicle_db.VehicleTypeID = vehicle.VehicleTypeID;

            context.Vehicles.Update(vehicle_db);
            await context.SaveChangesAsync();
            return vehicle_db;
        }
    }
}
