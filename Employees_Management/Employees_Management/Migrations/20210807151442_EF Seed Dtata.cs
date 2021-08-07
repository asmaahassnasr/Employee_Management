using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees_Management.Migrations
{
    public partial class EFSeedDtata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Emial", "Name" },
                values: new object[] { 1, 1, "emp1@gmail.com", "Emp001" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
