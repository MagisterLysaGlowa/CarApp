using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class hotFix2 : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_VehicleTypeID",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_GearboxID",
                table: "Vehicles",
                newName: "IX_Vehicles_GearboxID");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_EngineID",
                table: "Vehicles",
                newName: "IX_Vehicles_EngineID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Engines_EngineID",
                table: "Vehicles",
                column: "EngineID",
                principalTable: "Engines",
                principalColumn: "EngineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Gearboxes_GearboxID",
                table: "Vehicles",
                column: "GearboxID",
                principalTable: "Gearboxes",
                principalColumn: "GearboxID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeID",
                table: "Vehicles",
                column: "VehicleTypeID",
                principalTable: "VehicleTypes",
                principalColumn: "VehicleTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Engines_EngineID",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Gearboxes_GearboxID",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeID",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleTypeID",
                table: "Cars",
                newName: "IX_Cars_VehicleTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_GearboxID",
                table: "Cars",
                newName: "IX_Cars_GearboxID");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_EngineID",
                table: "Cars",
                newName: "IX_Cars_EngineID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "VehicleID");

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
        }
    }
}
