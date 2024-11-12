using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hotFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Engines_EngineID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Gearboxes_GearboxID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleTypes_VehicleTypeID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Engines_FuelTypes_FuelTypeID",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EngineID",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineID",
                table: "Cars",
                column: "EngineID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Engines_EngineID",
                table: "Cars",
                column: "EngineID",
                principalTable: "Engines",
                principalColumn: "EngineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Gearboxes_GearboxID",
                table: "Cars",
                column: "GearboxID",
                principalTable: "Gearboxes",
                principalColumn: "GearboxID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleTypes_VehicleTypeID",
                table: "Cars",
                column: "VehicleTypeID",
                principalTable: "VehicleTypes",
                principalColumn: "VehicleTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_FuelTypes_FuelTypeID",
                table: "Engines",
                column: "FuelTypeID",
                principalTable: "FuelTypes",
                principalColumn: "FuelTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Engines_EngineID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Gearboxes_GearboxID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_VehicleTypes_VehicleTypeID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Engines_FuelTypes_FuelTypeID",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EngineID",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineID",
                table: "Cars",
                column: "EngineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Engines_EngineID",
                table: "Cars",
                column: "EngineID",
                principalTable: "Engines",
                principalColumn: "EngineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Gearboxes_GearboxID",
                table: "Cars",
                column: "GearboxID",
                principalTable: "Gearboxes",
                principalColumn: "GearboxID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_VehicleTypes_VehicleTypeID",
                table: "Cars",
                column: "VehicleTypeID",
                principalTable: "VehicleTypes",
                principalColumn: "VehicleTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_FuelTypes_FuelTypeID",
                table: "Engines",
                column: "FuelTypeID",
                principalTable: "FuelTypes",
                principalColumn: "FuelTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
