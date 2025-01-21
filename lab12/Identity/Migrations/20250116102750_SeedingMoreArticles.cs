using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedingMoreArticles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Fruit" },
                    { 4, "Vegetable" },
                    { 5, "Meat" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpirationDate", "ImageName", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Apple", 0.5m, 30 },
                    { 4, 4, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Carrot", 0.3m, 40 },
                    { 5, 5, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chicken", 2.5m, 10 },
                    { 500, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 500", 12.2m, 200 },
                    { 501, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 501", 12.2m, 200 },
                    { 502, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 502", 12.2m, 200 },
                    { 503, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 503", 12.2m, 200 },
                    { 504, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 504", 12.2m, 200 },
                    { 505, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 505", 12.2m, 200 },
                    { 506, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 506", 12.2m, 200 },
                    { 507, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 507", 12.2m, 200 },
                    { 508, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 508", 12.2m, 200 },
                    { 509, 5, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Meat 509", 12.2m, 200 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
