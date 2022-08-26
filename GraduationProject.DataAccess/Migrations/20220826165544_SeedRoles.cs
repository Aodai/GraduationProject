using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.DataAccess.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24ab88ea-95cd-4e6e-82f7-b89845f2b365", "4861f260-5e6f-4f12-8e1d-e6d5a9ec03b7", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40da39f6-f6eb-40ab-b5ac-44e5f554a1b1", "fc0cec18-2d80-4e5a-ac02-ed116c7bfb97", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24ab88ea-95cd-4e6e-82f7-b89845f2b365");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40da39f6-f6eb-40ab-b5ac-44e5f554a1b1");
        }
    }
}
