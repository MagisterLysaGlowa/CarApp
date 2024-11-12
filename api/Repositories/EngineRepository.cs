using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class EngineRepository : IEngineRepository
    {
        private readonly AppDbContext context;
        public EngineRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Engine> Create(Engine engine)
        {
            await context.Engines.AddAsync(engine);
            await context.SaveChangesAsync();
            return engine;
        }

        public async Task<int> Delete(int engineID)
        {
            Engine? engine = await context.Engines.FindAsync(engineID);
            if (engine == null) return 0;
            context.Engines.Remove(engine);
            return await context.SaveChangesAsync();
        }

        public async Task<Engine> Get(int engineID)
        {
            Engine? engine = await context.Engines.FindAsync(engineID);
            if (engine == null) return null!;
            return engine;
        }

        public async Task<List<Engine>> GetAll()
        {
            List<Engine> engines = await context.Engines.Include(z=>z.FuelType).ToListAsync();
            return engines;
        }

        public async Task<Engine> Update(Engine engine, int engineID)
        {
            Engine? engine_db = await context.Engines.FindAsync(engineID)!;
            if (engine_db == null)
            {
                throw new Exception($"Failed to update gearbox with gearbox id = {engineID}");
            }

            engine_db.Capacity = engine.Capacity;
            engine_db.Horsepower = engine.Horsepower;
            engine_db.Torque = engine.Torque;
            engine_db.Cylinders = engine.Cylinders;
            engine_db.FuelTypeID = engine.FuelTypeID;

            context.Engines.Update(engine_db);
            await context.SaveChangesAsync();
            return engine_db;
        }
    }
}
