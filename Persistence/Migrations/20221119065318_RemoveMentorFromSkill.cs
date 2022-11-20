using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemoveMentorFromSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Mentors_MentorId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_MentorId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "MentorId",
                table: "Skills");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MentorId",
                table: "Skills",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_MentorId",
                table: "Skills",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Mentors_MentorId",
                table: "Skills",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
