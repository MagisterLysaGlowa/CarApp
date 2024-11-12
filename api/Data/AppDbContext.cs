using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Cars { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<Gearbox> Gearboxes { get; set; } = null!;
        public DbSet<FuelType> FuelTypes { get; set; } = null!;
        public DbSet<VehicleType> VehicleTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Car entity
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(c => c.CarID);

                // One-to-One relationship between Car and Engine
                entity.HasOne(c => c.Engine)
                      .WithOne()
                      .HasForeignKey<Vehicle>(c => c.EngineID)
                      .OnDelete(DeleteBehavior.Restrict);

                // One-to-Many relationship between Car and Gearbox
                entity.HasOne(c => c.Gearbox)
                      .WithMany()
                      .HasForeignKey(c => c.GearboxID)
                      .OnDelete(DeleteBehavior.Restrict);

                // One-to-Many relationship between Car and VehicleType
                entity.HasOne(c => c.VehicleType)
                      .WithMany()
                      .HasForeignKey(c => c.VehicleTypeID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Engine entity
            modelBuilder.Entity<Engine>(entity =>
            {
                entity.HasKey(e => e.EngineID);
                entity.HasOne(e => e.FuelType)
                      .WithMany()
                      .HasForeignKey(e => e.FuelTypeID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Gearbox entity
            modelBuilder.Entity<Gearbox>(entity =>
            {
                entity.HasKey(g => g.GearboxID);
            });

            // Configure FuelType entity
            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.HasKey(f => f.FuelTypeID);
            });

            // Configure VehicleType entity
            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasKey(v => v.VehicleTypeID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
