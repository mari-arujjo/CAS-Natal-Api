using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RefactorCreatedUpdatedDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonGlossaries");

            migrationBuilder.DropTable(
                name: "Glossaries");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "171a2ef5-43b2-48e2-aeef-463d140ce34c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dda342e0-4705-4b68-8728-59a67e461794");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Enrollments",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Enrollments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Enrollments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    SourceIp = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Table = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RecordId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeforeState = table.Column<string>(type: "text", nullable: true),
                    AfterState = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Signs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SignCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonsSigns",
                columns: table => new
                {
                    LessonsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SignsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonsSigns", x => new { x.LessonsId, x.SignsId });
                    table.ForeignKey(
                        name: "FK_LessonsSigns_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonsSigns_Signs_SignsId",
                        column: x => x.SignsId,
                        principalTable: "Signs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29737e31-c747-4260-854c-7d4b0526ebe8", null, "Default", "DEFAULT" },
                    { "5b1c19b5-6033-4d16-ad67-3f872956c23b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonsSigns_SignsId",
                table: "LessonsSigns",
                column: "SignsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonsSigns");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Signs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29737e31-c747-4260-854c-7d4b0526ebe8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1c19b5-6033-4d16-ad67-3f872956c23b");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Enrollments",
                newName: "Timestamp");

            migrationBuilder.CreateTable(
                name: "Glossaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    GlossaryCode = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<byte[]>(type: "bytea", nullable: true),
                    Sign = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glossaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LessonGlossaries",
                columns: table => new
                {
                    GlossariesId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonGlossaries", x => new { x.GlossariesId, x.LessonsId });
                    table.ForeignKey(
                        name: "FK_LessonGlossaries_Glossaries_GlossariesId",
                        column: x => x.GlossariesId,
                        principalTable: "Glossaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonGlossaries_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "171a2ef5-43b2-48e2-aeef-463d140ce34c", null, "Admin", "ADMIN" },
                    { "dda342e0-4705-4b68-8728-59a67e461794", null, "Default", "DEFAULT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonGlossaries_LessonsId",
                table: "LessonGlossaries",
                column: "LessonsId");
        }
    }
}
