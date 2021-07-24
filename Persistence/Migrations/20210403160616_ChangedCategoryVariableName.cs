using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangedCategoryVariableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfClients",
                table: "Categories",
                newName: "NumberOfConsultants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfConsultants",
                table: "Categories",
                newName: "NumberOfClients");
        }
    }
}
