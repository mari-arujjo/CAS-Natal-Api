using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacoesQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73a22cbf-da61-45fc-93a0-e773f63886be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfbd5c80-4f13-4744-ae1d-8d028e4ae086");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b077651-f269-4f71-9ef3-721e5d27fb95", null, "Admin", "ADMIN" },
                    { "87ab8a73-00d0-41ce-ae2d-e009c5df1c63", null, "Default", "DEFAULT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptions_QuestionId",
                table: "QuizOptions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizOptions_QuizQuestions_QuestionId",
                table: "QuizOptions",
                column: "QuestionId",
                principalTable: "QuizQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizOptions_QuizQuestions_QuestionId",
                table: "QuizOptions");

            migrationBuilder.DropIndex(
                name: "IX_QuizOptions_QuestionId",
                table: "QuizOptions");

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
                    { "73a22cbf-da61-45fc-93a0-e773f63886be", null, "Default", "DEFAULT" },
                    { "dfbd5c80-4f13-4744-ae1d-8d028e4ae086", null, "Admin", "ADMIN" }
                });
        }
    }
}
