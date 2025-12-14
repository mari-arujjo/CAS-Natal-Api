using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCreatedUpdatedDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21d3b5a6-58aa-4341-afb2-111f5856b03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a70cbba4-15cd-4b1e-ab52-a05b962b6ae3");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "QuizQuestions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "QuizQuestions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "QuizQuestions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "QuizOptions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "QuizOptions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "QuizOptions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "937cc5fc-b907-4d1f-bd4f-d9dd21d8ff08", null, "Admin", "ADMIN" },
                    { "acd97763-cf0d-4593-984f-a7891d5fc0af", null, "Default", "DEFAULT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "937cc5fc-b907-4d1f-bd4f-d9dd21d8ff08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acd97763-cf0d-4593-984f-a7891d5fc0af");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "QuizQuestions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "QuizOptions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "QuizOptions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "QuizOptions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21d3b5a6-58aa-4341-afb2-111f5856b03c", null, "Admin", "ADMIN" },
                    { "a70cbba4-15cd-4b1e-ab52-a05b962b6ae3", null, "Default", "DEFAULT" }
                });
        }
    }
}
