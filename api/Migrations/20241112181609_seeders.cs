using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "FuelTypeID", "Name" },
                values: new object[,]
                {
                    { 1, "Dizel" },
                    { 2, "Benzyna" }
                });

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "GearboxID", "Speeds", "Type" },
                values: new object[] { 1, 6, "CVT" });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "VehicleTypeID", "Name" },
                values: new object[,]
                {
                    { 1, "Osobowe" },
                    { 2, "Ciezarowe" },
                    { 3, "Motor" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "EngineID", "Capacity", "Cylinders", "FuelTypeID", "Horsepower", "Torque" },
                values: new object[] { 1, 6.2999999999999998, 8, 2, 503, 600 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleID", "BodyType", "Color", "EngineID", "GearboxID", "Mileage", "Model", "Price", "SeatingCapacity", "VIN", "VehicleTypeID", "Year" },
                values: new object[] { 1, "Sedan", "Czarny", 1, 1, 10000.0, "Ford", 100000m, 5, "1234567890", 1, 2000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "FuelTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "EngineID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "GearboxID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "FuelTypeID",
                keyValue: 2);
        }
    }
}
