using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ca929d2-7ec5-40b9-8137-bc6fa44a56a1", "775002fe-2136-4414-bba3-bf7930c6705b", "Admin", "ADMIN" },
                    { "8b2345d2-8ec5-41b9-9248-bc6fa44a56b2", "0031bf66-f21a-4ce7-a643-86fedca625cb", "Doctor", "DOCTOR" },
                    { "9c3456d3-9ec6-42b9-0359-bc6fa44a56c3", "1ac2b7d2-d93a-41e7-bd72-51dd4854b1fe", "Patient", "PATIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca929d2-7ec5-40b9-8137-bc6fa44a56a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2345d2-8ec5-41b9-9248-bc6fa44a56b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c3456d3-9ec6-42b9-0359-bc6fa44a56c3");
        }
    }
}
