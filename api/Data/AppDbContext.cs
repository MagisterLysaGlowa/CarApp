using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data {
    public class AppDbContext :DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; } = default!;
        public DbSet<Engine> Engines { get; set; } = default!;
        public DbSet<Gearbox> Gearboxes { get; set; } = default!;
        public DbSet<FuelType> FuelTypes { get; set; } = default!;
        public DbSet<VehicleType> VehicleTypes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Configure Car entity
            modelBuilder.Entity<Vehicle>(entity => {
                entity.HasKey(c => c.VehicleID);

                // One-to-One relationship between Car and Engine
                entity.HasOne(c => c.Engine)
                      .WithMany() // Pozwala na współdzielenie silnika przez wiele pojazdów
                      .HasForeignKey(c => c.EngineID)
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
            modelBuilder.Entity<Engine>(entity => {
                entity.HasKey(e => e.EngineID);
                entity.HasOne(e => e.FuelType)
                      .WithMany()
                      .HasForeignKey(e => e.FuelTypeID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Gearbox entity
            modelBuilder.Entity<Gearbox>(entity => {
                entity.HasKey(g => g.GearboxID);
            });

            // Configure FuelType entity
            modelBuilder.Entity<FuelType>(entity => {
                entity.HasKey(f => f.FuelTypeID);
            });

            // Configure VehicleType entity
            modelBuilder.Entity<VehicleType>(entity => {
                entity.HasKey(v => v.VehicleTypeID);
            });



            modelBuilder.Entity<VehicleType>().HasData(new List<VehicleType>() {
                new VehicleType() {
                    VehicleTypeID=1,
                    Name="Osobowe"
                },
                new VehicleType() {
                    VehicleTypeID=2,
                    Name="Ciezarowe" },
                new VehicleType() {
                    VehicleTypeID=3,
                    Name="Motor",
                }
            });

            modelBuilder.Entity<FuelType>().HasData(new List<FuelType>() {
                new FuelType() {
                    FuelTypeID=1,
                    Name="Diesel"
                }, new FuelType() {
                    FuelTypeID =2,
                    Name="Benzyna"
                }
            });

            modelBuilder.Entity<Engine>().HasData(new List<Engine>() {
                new Engine() {
                  EngineID=1,
                  Capacity=6.3,
                  Cylinders=8,
                  FuelTypeID=2,
                  Horsepower=503,
                  Torque=600
                },
                 new Engine() {
                  EngineID=2,
                  Capacity=1.9,
                  Cylinders=4,
                  FuelTypeID=1,
                  Horsepower=100,
                  Torque=100
                }
            });


            modelBuilder.Entity<Gearbox>().HasData(new List<Gearbox>() {
                new Gearbox() {
                    GearboxID=1,
                    Speeds=6,
                    Type="Manualna",
                },
                new Gearbox() {
                    GearboxID=6,
                    Speeds=6,
                    Type="Automatyczna"
                }
            });

            modelBuilder.Entity<Vehicle>().HasData(new List<Vehicle>() {
                new Vehicle() {
                    Color="Czarny",
                    BodyType="Sedan",
                    EngineID=1,
                    GearboxID=1,
                    Mileage=10000,
                    Price=100000,
                    Model="Ford",
                    VehicleID=1,
                    VehicleTypeID=1,
                    Year=2000,
                    VIN="1234567890",
                    SeatingCapacity=5,
                }
            });
            base.OnModelCreating(modelBuilder);


        }
    }
}
