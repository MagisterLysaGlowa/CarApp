using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly AppDbContext context;
        public FuelTypeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<FuelType> Create(FuelType fuelType)
        {
            await context.FuelTypes.AddAsync(fuelType);
            await context.SaveChangesAsync();
            return fuelType;
        }

        public async Task<int> Delete(int fuelTypeID)
        {
            FuelType? fuelType = await context.FuelTypes.FindAsync(fuelTypeID);
            if (fuelType == null) return 0;
            context.FuelTypes.Remove(fuelType);
            return await context.SaveChangesAsync();
        }

        public async Task<FuelType> Get(int fuelTypeID)
        {
            FuelType? fuelType = await context.FuelTypes.FindAsync(fuelTypeID);
            if (fuelType == null) return null!;
            return fuelType;
        }

        public async Task<List<FuelType>> GetAll()
        {
            List<FuelType> fuelTypes = await context.FuelTypes.ToListAsync();
            return fuelTypes;
        }

        public async Task<FuelType> Update(FuelType fuelType, int fuelTypeID)
        {
            FuelType? fuelType_db = await context.FuelTypes.FindAsync(fuelTypeID)!;
            if (fuelType_db == null)
            {
                throw new Exception($"Failed to update fuel type with fuel type id = {fuelTypeID}");
            }

            fuelType_db.Name = fuelType.Name;


            context.FuelTypes.Update(fuelType_db);
            await context.SaveChangesAsync();
            return fuelType_db;
        }
    }
}
