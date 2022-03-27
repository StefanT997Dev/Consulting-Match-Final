using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ModifyMentorEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Photos_PhotoId",
                table: "Mentors");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_PhotoId",
                table: "Mentors");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Mentors",
                newName: "Category");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Mentors",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<List<string>>(
                name: "Skills",
                table: "Mentors",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Mentors");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Mentors",
                newName: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_PhotoId",
                table: "Mentors",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Photos_PhotoId",
                table: "Mentors",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
