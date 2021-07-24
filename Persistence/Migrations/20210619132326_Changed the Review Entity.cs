using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangedtheReviewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ConsultantId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "ConsultantId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                columns: new[] { "ConsultantId", "ClientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ClientId",
                table: "Reviews",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ConsultantId",
                table: "Reviews",
                column: "ConsultantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ClientId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ConsultantId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "ConsultantId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ConsultantId",
                table: "Reviews",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ConsultantId",
                table: "Reviews",
                column: "ConsultantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
