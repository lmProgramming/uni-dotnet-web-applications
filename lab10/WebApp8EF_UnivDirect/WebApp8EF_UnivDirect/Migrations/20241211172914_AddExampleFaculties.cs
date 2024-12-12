using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp8EF_UnivDirect.Migrations
{
    /// <inheritdoc />
    public partial class AddExampleFaculties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "FacultyId", "FacultyName" },
                values: new object[,]
                {
                    { 1, "Science" },
                    { 2, "Arts" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "FacultyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "FacultyId",
                keyValue: 2);
        }
    }
}
