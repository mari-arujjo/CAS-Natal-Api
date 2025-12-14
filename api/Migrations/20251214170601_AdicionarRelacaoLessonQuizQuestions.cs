using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacaoLessonQuizQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b077651-f269-4f71-9ef3-721e5d27fb95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ab8a73-00d0-41ce-ae2d-e009c5df1c63");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21d3b5a6-58aa-4341-afb2-111f5856b03c", null, "Admin", "ADMIN" },
                    { "a70cbba4-15cd-4b1e-ab52-a05b962b6ae3", null, "Default", "DEFAULT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_LessonId",
                table: "QuizQuestions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Lessons_LessonId",
                table: "QuizQuestions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Lessons_LessonId",
                table: "QuizQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_LessonId",
                table: "QuizQuestions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21d3b5a6-58aa-4341-afb2-111f5856b03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a70cbba4-15cd-4b1e-ab52-a05b962b6ae3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b077651-f269-4f71-9ef3-721e5d27fb95", null, "Admin", "ADMIN" },
                    { "87ab8a73-00d0-41ce-ae2d-e009c5df1c63", null, "Default", "DEFAULT" }
                });
        }
    }
}
