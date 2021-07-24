using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedScheduleAggregation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConsultantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => new { x.ClientId, x.ConsultantId });
                    table.ForeignKey(
                        name: "FK_Schedules_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_AspNetUsers_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ConsultantId",
                table: "Schedules",
                column: "ConsultantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
