using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Unity.Migrations.CropTreatment
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CropTreatments",
                columns: table => new
                {
                    CropTreatmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropId = table.Column<int>(type: "int", nullable: true),
                    FertilizerId = table.Column<int>(type: "int", nullable: true),
                    TypeTreatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTreatment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductUsed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApplicationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropTreatments", x => x.CropTreatmentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CropTreatments");
        }
    }
}
