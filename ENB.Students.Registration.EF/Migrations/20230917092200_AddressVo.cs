using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ENB.Students.Registration.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddressVo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "458f00f0-14a7-4c1a-b0ae-494a7bd43ca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72659bed-2413-4460-8272-91808a0f9529");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c171d747-c8f0-45bc-9ead-a3d29c6b5fa6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d36e9567-218b-48d5-a304-2bd054d3b52a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02b18694-0471-4629-9fec-711af925b47d", null, "Visitor", "VISITOR" },
                    { "dd50602e-6c59-4e51-9bb8-b175fccff372", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02b18694-0471-4629-9fec-711af925b47d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "481dc667-963e-4b70-bfda-fd319a4f2e71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c78b218-f791-43d3-8c65-81eaa5c47fae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd50602e-6c59-4e51-9bb8-b175fccff372");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "458f00f0-14a7-4c1a-b0ae-494a7bd43ca8", null, "Visitor", "VISITOR" },
                    { "d36e9567-218b-48d5-a304-2bd054d3b52a", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
