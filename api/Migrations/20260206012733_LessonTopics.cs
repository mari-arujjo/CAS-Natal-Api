using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class LessonTopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "937cc5fc-b907-4d1f-bd4f-d9dd21d8ff08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acd97763-cf0d-4593-984f-a7891d5fc0af");

            migrationBuilder.CreateTable(
                name: "LessonTopic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TextContent = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonTopic_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cfa1f13-8c4c-4304-9d21-9c49fe8d177a", null, "Admin", "ADMIN" },
                    { "9c23c72b-348b-4511-99a0-424a1538643d", null, "Default", "DEFAULT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonTopic_LessonId",
                table: "LessonTopic",
                column: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonTopic");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cfa1f13-8c4c-4304-9d21-9c49fe8d177a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c23c72b-348b-4511-99a0-424a1538643d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "937cc5fc-b907-4d1f-bd4f-d9dd21d8ff08", null, "Admin", "ADMIN" },
                    { "acd97763-cf0d-4593-984f-a7891d5fc0af", null, "Default", "DEFAULT" }
                });
        }
    }
}
