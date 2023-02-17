using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotCarlaREST.Migrations
{
    public partial class friday_carla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "raid",
                columns: table => new
                {
                    RaidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raiddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raidname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raid", x => x.RaidId);
                });

            migrationBuilder.CreateTable(
                name: "Raiduser",
                columns: table => new
                {
                    UserDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaidId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raiduser", x => x.UserDId);
                    table.ForeignKey(
                        name: "FK_Raiduser_raid_RaidId",
                        column: x => x.RaidId,
                        principalTable: "raid",
                        principalColumn: "RaidId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raiduser_RaidId",
                table: "Raiduser",
                column: "RaidId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raiduser");

            migrationBuilder.DropTable(
                name: "raid");
        }
    }
}
