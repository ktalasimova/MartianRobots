using Microsoft.EntityFrameworkCore.Migrations;

namespace MartianRobots.Persistence.Migrations
{
    public partial class AddedExploredSurfaceRateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "explored_surface_rate",
                table: "games",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "explored_surface_rate",
                table: "games");
        }
    }
}
