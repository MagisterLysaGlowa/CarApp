﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241112152151_hotFix2")]
    partial class hotFix2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Engine", b =>
                {
                    b.Property<int>("EngineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EngineID"));

                    b.Property<double>("Capacity")
                        .HasColumnType("double precision");

                    b.Property<int>("Cylinders")
                        .HasColumnType("integer");

                    b.Property<int>("FuelTypeID")
                        .HasColumnType("integer");

                    b.Property<int>("Horsepower")
                        .HasColumnType("integer");

                    b.Property<int>("Torque")
                        .HasColumnType("integer");

                    b.HasKey("EngineID");

                    b.HasIndex("FuelTypeID");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("api.Models.FuelType", b =>
                {
                    b.Property<int>("FuelTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FuelTypeID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FuelTypeID");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("api.Models.Gearbox", b =>
                {
                    b.Property<int>("GearboxID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GearboxID"));

                    b.Property<int>("Speeds")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GearboxID");

                    b.ToTable("Gearboxes");
                });

            modelBuilder.Entity("api.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VehicleID"));

                    b.Property<string>("BodyType")
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<int>("EngineID")
                        .HasColumnType("integer");

                    b.Property<int>("GearboxID")
                        .HasColumnType("integer");

                    b.Property<double>("Mileage")
                        .HasColumnType("double precision");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("VIN")
                        .HasColumnType("text");

                    b.Property<int>("VehicleTypeID")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("VehicleID");

                    b.HasIndex("EngineID")
                        .IsUnique();

                    b.HasIndex("GearboxID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("api.Models.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VehicleTypeID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VehicleTypeID");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("api.Models.Engine", b =>
                {
                    b.HasOne("api.Models.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FuelType");
                });

            modelBuilder.Entity("api.Models.Vehicle", b =>
                {
                    b.HasOne("api.Models.Engine", "Engine")
                        .WithOne()
                        .HasForeignKey("api.Models.Vehicle", "EngineID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api.Models.Gearbox", "Gearbox")
                        .WithMany()
                        .HasForeignKey("GearboxID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Engine");

                    b.Navigation("Gearbox");

                    b.Navigation("VehicleType");
                });
#pragma warning restore 612, 618
        }
    }
}
