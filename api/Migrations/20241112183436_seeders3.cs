using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seeders3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "EngineID", "Capacity", "Cylinders", "FuelTypeID", "Horsepower", "Torque" },
                values: new object[] { 2, 1.8999999999999999, 4, 1, 100, 100 });

            migrationBuilder.UpdateData(
                table: "Gearboxes",
                keyColumn: "GearboxID",
                keyValue: 1,
                column: "Type",
                value: "Manualna");

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "GearboxID", "Speeds", "Type" },
                values: new object[] { 6, 6, "Automatyczna" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "EngineID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "GearboxID",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Gearboxes",
                keyColumn: "GearboxID",
                keyValue: 1,
                column: "Type",
                value: "CVT");
        }
    }
}
