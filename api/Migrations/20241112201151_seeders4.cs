using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seeders4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EngineID",
                table: "Vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineID",
                table: "Vehicles",
                column: "EngineID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EngineID",
                table: "Vehicles");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EngineID",
                table: "Vehicles",
                column: "EngineID",
                unique: true);
        }
    }
}
