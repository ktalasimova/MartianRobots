using Microsoft.EntityFrameworkCore.Migrations;

namespace MartianRobots.Persistence.Migrations
{
    public partial class RenameGameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "winning_robots_Count",
                table: "games",
                newName: "winning_robots_count");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "winning_robots_count",
                table: "games",
                newName: "winning_robots_Count");
        }
    }
}
