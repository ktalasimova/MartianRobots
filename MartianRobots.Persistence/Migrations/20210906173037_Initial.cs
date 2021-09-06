using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartianRobots.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    lost_robots_count = table.Column<int>(type: "int", nullable: false),
                    winning_robots_Count = table.Column<int>(type: "int", nullable: false),
                    played_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_results",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    instructions = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    game_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    initial_coordinate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    init_orientation = table.Column<int>(type: "int", nullable: false),
                    end_coordinate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_orientation = table.Column<int>(type: "int", nullable: false),
                    lost = table.Column<bool>(type: "bit", nullable: false),
                    calculated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game_results", x => x.id);
                    table.ForeignKey(
                        name: "FK_game_results_games_game_id",
                        column: x => x.game_id,
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_game_results_game_id",
                table: "game_results",
                column: "game_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_results");

            migrationBuilder.DropTable(
                name: "games");
        }
    }
}
