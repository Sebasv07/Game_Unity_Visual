using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game_Unity.Migrations.MaturationMonitoring
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaturationMonitorings",
                columns: table => new
                {
                    MaturationMonitoringId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropId = table.Column<int>(type: "int", nullable: true),
                    EstimatedRipeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstimatedPlanningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaturationState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaturationMonitorings", x => x.MaturationMonitoringId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaturationMonitorings");
        }
    }
}
