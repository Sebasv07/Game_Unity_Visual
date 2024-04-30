using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Unity.Migrations.SoilQuality
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoilQualitys",
                columns: table => new
                {
                    SoilQualityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSoilQuality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NutrientLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PH = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilQualitys", x => x.SoilQualityId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoilQualitys");
        }
    }
}
