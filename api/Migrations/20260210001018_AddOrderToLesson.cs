using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderToLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cfa1f13-8c4c-4304-9d21-9c49fe8d177a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c23c72b-348b-4511-99a0-424a1538643d");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6cd61b0-14da-4023-89ab-73f71f815da9", null, "Admin", "ADMIN" },
                    { "d22d4470-dde9-443d-9fb8-ad812b042607", null, "Default", "DEFAULT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cd61b0-14da-4023-89ab-73f71f815da9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d22d4470-dde9-443d-9fb8-ad812b042607");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Lessons");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cfa1f13-8c4c-4304-9d21-9c49fe8d177a", null, "Admin", "ADMIN" },
                    { "9c23c72b-348b-4511-99a0-424a1538643d", null, "Default", "DEFAULT" }
                });
        }
    }
}
