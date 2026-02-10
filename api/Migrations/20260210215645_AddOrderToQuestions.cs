using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderToQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cd61b0-14da-4023-89ab-73f71f815da9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d22d4470-dde9-443d-9fb8-ad812b042607");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "QuizQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2866b7e8-6d00-4aef-94cb-86b072439944", null, "Default", "DEFAULT" },
                    { "6d121049-2408-44e4-9e9c-f188ef049e11", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2866b7e8-6d00-4aef-94cb-86b072439944");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d121049-2408-44e4-9e9c-f188ef049e11");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "QuizQuestions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6cd61b0-14da-4023-89ab-73f71f815da9", null, "Admin", "ADMIN" },
                    { "d22d4470-dde9-443d-9fb8-ad812b042607", null, "Default", "DEFAULT" }
                });
        }
    }
}
