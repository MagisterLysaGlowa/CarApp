using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class GearboxRepository : IGearboxRepository
    {
        private readonly AppDbContext context;
        public GearboxRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Gearbox> Create(Gearbox gearbox)
        {
            await context.Gearboxes.AddAsync(gearbox);
            await context.SaveChangesAsync();
            return gearbox;
        }

        public async Task<int> Delete(int gearboxID)
        {
            Gearbox? gearbox = await context.Gearboxes.FindAsync(gearboxID);
            if (gearbox == null) return 0;
            context.Gearboxes.Remove(gearbox);
            return await context.SaveChangesAsync();
        }

        public async Task<Gearbox> Get(int gearboxID)
        {
            Gearbox? gearbox = await context.Gearboxes.FindAsync(gearboxID);
            if (gearbox == null) return null!;
            return gearbox;
        }

        public async Task<List<Gearbox>> GetAll()
        {
            List<Gearbox> gearboxes = await context.Gearboxes.ToListAsync();
            return gearboxes;
        }

        public async Task<Gearbox> Update(Gearbox gearbox, int gearboxID)
        {
            Gearbox? gearbox_db = await context.Gearboxes.FindAsync(gearboxID)!;
            if (gearbox_db == null)
            {
                throw new Exception($"Failed to update gearbox with gearbox id = {gearboxID}");
            }

            gearbox_db.Type = gearbox.Type;
            gearbox_db.Speeds = gearbox.Speeds;


            context.Gearboxes.Update(gearbox_db);
            await context.SaveChangesAsync();
            return gearbox_db;
        }
    }
}
