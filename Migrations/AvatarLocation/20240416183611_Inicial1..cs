using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Unity.Migrations.AvatarLocation
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvatarLocations",
                columns: table => new
                {
                    AvatarLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DetectiveId = table.Column<int>(type: "int", nullable: false),
                    CoordinatesX = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoordinatesY = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoordinatesZ = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvatarLocations", x => x.AvatarLocationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvatarLocations");
        }
    }
}
