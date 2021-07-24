using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedSkillUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserSkills",
                columns: table => new
                {
                    ConsultantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserSkills", x => new { x.ConsultantId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_AppUserSkills_AspNetUsers_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserSkills_SkillId",
                table: "AppUserSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserSkills");
        }
    }
}
