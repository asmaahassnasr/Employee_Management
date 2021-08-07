using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees_Management.Migrations
{
    public partial class ChangeSeededDtata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Emial", "Name" },
                values: new object[] { 2, 2, "emp2@gmail.com", "Emp002" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Emial", "Name" },
                values: new object[] { 3, 3, "emp3@gmail.com", "Emp003" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
