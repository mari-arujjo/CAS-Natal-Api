using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelasIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AppUserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AppUserId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4f965fa-b304-4ef7-af28-db295ab2a3b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c32b8a07-f8f3-4665-8981-b3a038647eef");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ffb4c09-b831-496b-a87b-d8bc5fe778d1", null, "Admin", "ADMIN" },
                    { "8ceeaeb3-addc-42f5-bb56-6793fad10330", null, "Default", "DEFAULT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ffb4c09-b831-496b-a87b-d8bc5fe778d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ceeaeb3-addc-42f5-bb56-6793fad10330");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4f965fa-b304-4ef7-af28-db295ab2a3b1", null, "Admin", "ADMIN" },
                    { "c32b8a07-f8f3-4665-8981-b3a038647eef", null, "Default", "DEFAULT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AppUserId",
                table: "Courses",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AppUserId",
                table: "Courses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
