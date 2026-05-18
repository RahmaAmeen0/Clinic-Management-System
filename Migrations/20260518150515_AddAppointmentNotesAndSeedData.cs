using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentNotesAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Doctors",
                newName: "DoctorId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notes",
                value: null);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { 3, "Children's Health Clinic", "Pediatrics" },
                    { 4, "Dental Care Clinic", "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                columns: new[] { "Id", "DoctorId", "EndTime", "StartTime", "WorkDay" },
                values: new object[] { 2, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), "Tuesday" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1,
                column: "LastName",
                value: "Belal");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "DepartmentId", "DoctorGender", "FirstName", "LastName", "Specialization" },
                values: new object[,]
                {
                    { 2, 2, "Male", "Mohamed", "Radwan", "Orthopedics" },
                    { 5, 1, "Male", "Samira", "Kamal", "Internal Medicine" },
                    { 6, 2, "Female", "Mariam", "Tarek", "General Surgery" }
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                columns: new[] { "Id", "DoctorId", "EndTime", "StartTime", "WorkDay" },
                values: new object[,]
                {
                    { 3, 2, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Monday" },
                    { 4, 2, new TimeSpan(0, 21, 0, 0, 0), new TimeSpan(0, 17, 0, 0, 0), "Wednesday" },
                    { 9, 5, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), "Monday" },
                    { 10, 6, new TimeSpan(0, 19, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0), "Wednesday" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "DepartmentId", "DoctorGender", "FirstName", "LastName", "Specialization" },
                values: new object[,]
                {
                    { 3, 3, "Female", "Abdelrahman", "Mosa", "Pediatrics" },
                    { 4, 4, "Female", "Rahma", "Ameen", "Dentistry" }
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                columns: new[] { "Id", "DoctorId", "EndTime", "StartTime", "WorkDay" },
                values: new object[,]
                {
                    { 5, 3, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "Thursday" },
                    { 6, 3, new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0), "Saturday" },
                    { 7, 4, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0), "Sunday" },
                    { 8, 4, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0), "Tuesday" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Doctors",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastName",
                value: "Hassan");
        }
    }
}
