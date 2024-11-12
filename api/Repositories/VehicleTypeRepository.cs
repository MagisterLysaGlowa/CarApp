using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly AppDbContext context;
        public VehicleTypeRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public async Task<VehicleType> Create(VehicleType vehicleType)
        {
            await context.VehicleTypes.AddAsync(vehicleType);
            await context.SaveChangesAsync();
            return vehicleType;
        }

        public async Task<int> Delete(int vehicleTypeID)
        {
            VehicleType? vehicleType = await context.VehicleTypes.FindAsync(vehicleTypeID);
            if (vehicleType == null) return 0;
            context.VehicleTypes.Remove(vehicleType);
            return await context.SaveChangesAsync();
        }

        public async Task<VehicleType> Get(int vehicleTypeID)
        {
            VehicleType? vehicleType = await context.VehicleTypes.FindAsync(vehicleTypeID);
            if (vehicleType == null) return null!;
            return vehicleType;
        }

        public async Task<List<VehicleType>> GetAll()
        {
            List<VehicleType> vehicleTypes = await context.VehicleTypes.ToListAsync();
            return vehicleTypes;
        }

        public async Task<VehicleType> Update(VehicleType vehicleType, int vehicleTypeID)
        {
            VehicleType? vehicleType_db = await context.VehicleTypes.FindAsync(vehicleTypeID)!;
            if (vehicleType_db == null)
            {
                throw new Exception($"Failed to update vehicle type with vehicle type id = {vehicleTypeID}");
            }

            vehicleType_db.Name = vehicleType.Name;

            context.VehicleTypes.Update(vehicleType_db);
            await context.SaveChangesAsync();
            return vehicleType_db;
        }
    }
}
