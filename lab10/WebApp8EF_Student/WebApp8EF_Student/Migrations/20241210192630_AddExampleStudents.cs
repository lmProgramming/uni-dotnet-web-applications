using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp8EF_Student.Migrations
{
    /// <inheritdoc />
    public partial class AddExampleStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Active", "BirthDate", "DepartmentId", "Gender", "Index", "Name" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1999, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 123456, "Newman" },
                    { 2, false, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 222222, "Yasmin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
