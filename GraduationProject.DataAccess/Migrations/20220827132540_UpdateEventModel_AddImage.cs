using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.DataAccess.Migrations
{
    public partial class UpdateEventModel_AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24ab88ea-95cd-4e6e-82f7-b89845f2b365");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40da39f6-f6eb-40ab-b5ac-44e5f554a1b1");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "09386242-704c-4338-8642-1b0bceb43f34", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", "691597a9-d247-46af-ae59-a17335f61209", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24ab88ea-95cd-4e6e-82f7-b89845f2b365", "4861f260-5e6f-4f12-8e1d-e6d5a9ec03b7", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40da39f6-f6eb-40ab-b5ac-44e5f554a1b1", "fc0cec18-2d80-4e5a-ac02-ed116c7bfb97", "User", "User" });
        }
    }
}
