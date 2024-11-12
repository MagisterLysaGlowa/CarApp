using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    FuelTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.FuelTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Gearboxes",
                columns: table => new
                {
                    GearboxID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Speeds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearboxes", x => x.GearboxID);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<double>(type: "double precision", nullable: false),
                    Horsepower = table.Column<int>(type: "integer", nullable: false),
                    Torque = table.Column<int>(type: "integer", nullable: false),
                    Cylinders = table.Column<int>(type: "integer", nullable: false),
                    FuelTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineID);
                    table.ForeignKey(
                        name: "FK_Engines_FuelTypes_FuelTypeID",
                        column: x => x.FuelTypeID,
                        principalTable: "FuelTypes",
                        principalColumn: "FuelTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    GearboxID = table.Column<int>(type: "integer", nullable: false),
                    Mileage = table.Column<double>(type: "double precision", nullable: false),
                    EngineID = table.Column<int>(type: "integer", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "integer", nullable: false),
                    BodyType = table.Column<string>(type: "text", nullable: true),
                    VIN = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    VehicleTypeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Cars_Engines_EngineID",
                        column: x => x.EngineID,
                        principalTable: "Engines",
                        principalColumn: "EngineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Gearboxes_GearboxID",
                        column: x => x.GearboxID,
                        principalTable: "Gearboxes",
                        principalColumn: "GearboxID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_VehicleTypes_VehicleTypeID",
                        column: x => x.VehicleTypeID,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineID",
                table: "Cars",
                column: "EngineID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GearboxID",
                table: "Cars",
                column: "GearboxID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VehicleTypeID",
                table: "Cars",
                column: "VehicleTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_FuelTypeID",
                table: "Engines",
                column: "FuelTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "FuelTypes");
        }
    }
}
