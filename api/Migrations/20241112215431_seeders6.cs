using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seeders6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "FuelTypeID",
                keyValue: 1,
                column: "Name",
                value: "Diesel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FuelTypes",
                keyColumn: "FuelTypeID",
                keyValue: 1,
                column: "Name",
                value: "Dizel");
        }
    }
}
