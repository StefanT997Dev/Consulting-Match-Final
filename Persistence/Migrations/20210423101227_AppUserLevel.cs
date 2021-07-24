using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AppUserLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelNumber = table.Column<int>(type: "int", nullable: false),
                    CreditsNeeded = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Level_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLevel",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfCredits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLevel", x => new { x.AppUserId, x.LevelId });
                    table.ForeignKey(
                        name: "FK_AppUserLevel_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserLevel_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLevel_LevelId",
                table: "AppUserLevel",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Level_CategoryId",
                table: "Level",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserLevel");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
