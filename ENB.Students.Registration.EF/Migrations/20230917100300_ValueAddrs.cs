using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ENB.Students.Registration.EF.Migrations
{
    /// <inheritdoc />
    public partial class ValueAddrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40028bc5-ecc4-4e57-abb4-f9e342fe8677");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59c376d9-7049-4d8d-b5bb-675f58c17622");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73f15f7d-6704-4188-90ca-788a0044fdcd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78da3052-5177-456e-b796-e23f9b84a55a");

            migrationBuilder.AlterColumn<string>(
                name: "Other_details",
                table: "Student",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<DateTime>(
                name: "StudentLocalAddress_Date_first_rental",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StudentLocalAddress_Date_left_university",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Student_Other_details",
                table: "Student",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5281a934-f9f7-4bd6-99b2-a2f64551dbe7", null, "Administrator", "ADMINISTRATOR" },
                    { "94a695e7-dac4-4110-aa8c-248892b6c346", null, "Visitor", "VISITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5281a934-f9f7-4bd6-99b2-a2f64551dbe7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63620614-7db2-4501-adac-a4226a3640c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70145bc5-2e94-41a0-8981-9211ddf24368");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a695e7-dac4-4110-aa8c-248892b6c346");

            migrationBuilder.DropColumn(
                name: "StudentLocalAddress_Date_first_rental",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentLocalAddress_Date_left_university",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Student_Other_details",
                table: "Student");

            migrationBuilder.AlterColumn<string>(
                name: "Other_details",
                table: "Student",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldDefaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40028bc5-ecc4-4e57-abb4-f9e342fe8677", null, "Visitor", "VISITOR" },
                    { "59c376d9-7049-4d8d-b5bb-675f58c17622", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
