using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bakery" },
                    { 2, "Dairy" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpirationDate", "ImageName", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bread", 1.2m, 20 },
                    { 2, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Milk", 0.8m, 10 },
                    { 10, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 10", 1.2m, 20 },
                    { 11, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 11", 1.2m, 20 },
                    { 12, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 12", 1.2m, 20 },
                    { 13, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 13", 1.2m, 20 },
                    { 14, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 14", 1.2m, 20 },
                    { 15, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 15", 1.2m, 20 },
                    { 16, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 16", 1.2m, 20 },
                    { 17, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 17", 1.2m, 20 },
                    { 18, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 18", 1.2m, 20 },
                    { 19, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 19", 1.2m, 20 },
                    { 20, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 20", 1.2m, 20 },
                    { 21, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 21", 1.2m, 20 },
                    { 22, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 22", 1.2m, 20 },
                    { 23, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 23", 1.2m, 20 },
                    { 24, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 24", 1.2m, 20 },
                    { 25, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 25", 1.2m, 20 },
                    { 26, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 26", 1.2m, 20 },
                    { 27, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 27", 1.2m, 20 },
                    { 28, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 28", 1.2m, 20 },
                    { 29, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 29", 1.2m, 20 },
                    { 30, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 30", 1.2m, 20 },
                    { 31, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 31", 1.2m, 20 },
                    { 32, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 32", 1.2m, 20 },
                    { 33, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 33", 1.2m, 20 },
                    { 34, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 34", 1.2m, 20 },
                    { 35, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 35", 1.2m, 20 },
                    { 36, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 36", 1.2m, 20 },
                    { 37, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 37", 1.2m, 20 },
                    { 38, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 38", 1.2m, 20 },
                    { 39, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 39", 1.2m, 20 },
                    { 40, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 40", 1.2m, 20 },
                    { 41, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 41", 1.2m, 20 },
                    { 42, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 42", 1.2m, 20 },
                    { 43, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 43", 1.2m, 20 },
                    { 44, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 44", 1.2m, 20 },
                    { 45, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 45", 1.2m, 20 },
                    { 46, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 46", 1.2m, 20 },
                    { 47, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 47", 1.2m, 20 },
                    { 48, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 48", 1.2m, 20 },
                    { 49, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 49", 1.2m, 20 },
                    { 50, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 50", 1.2m, 20 },
                    { 51, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 51", 1.2m, 20 },
                    { 52, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 52", 1.2m, 20 },
                    { 53, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 53", 1.2m, 20 },
                    { 54, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 54", 1.2m, 20 },
                    { 55, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 55", 1.2m, 20 },
                    { 56, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 56", 1.2m, 20 },
                    { 57, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 57", 1.2m, 20 },
                    { 58, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 58", 1.2m, 20 },
                    { 59, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 59", 1.2m, 20 },
                    { 60, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 60", 1.2m, 20 },
                    { 61, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 61", 1.2m, 20 },
                    { 62, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 62", 1.2m, 20 },
                    { 63, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 63", 1.2m, 20 },
                    { 64, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 64", 1.2m, 20 },
                    { 65, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 65", 1.2m, 20 },
                    { 66, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 66", 1.2m, 20 },
                    { 67, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 67", 1.2m, 20 },
                    { 68, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 68", 1.2m, 20 },
                    { 69, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 69", 1.2m, 20 },
                    { 70, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 70", 1.2m, 20 },
                    { 71, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 71", 1.2m, 20 },
                    { 72, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 72", 1.2m, 20 },
                    { 73, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 73", 1.2m, 20 },
                    { 74, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 74", 1.2m, 20 },
                    { 75, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 75", 1.2m, 20 },
                    { 76, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 76", 1.2m, 20 },
                    { 77, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 77", 1.2m, 20 },
                    { 78, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 78", 1.2m, 20 },
                    { 79, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 79", 1.2m, 20 },
                    { 80, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 80", 1.2m, 20 },
                    { 81, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 81", 1.2m, 20 },
                    { 82, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 82", 1.2m, 20 },
                    { 83, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 83", 1.2m, 20 },
                    { 84, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 84", 1.2m, 20 },
                    { 85, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 85", 1.2m, 20 },
                    { 86, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 86", 1.2m, 20 },
                    { 87, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 87", 1.2m, 20 },
                    { 88, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 88", 1.2m, 20 },
                    { 89, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 89", 1.2m, 20 },
                    { 90, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 90", 1.2m, 20 },
                    { 91, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 91", 1.2m, 20 },
                    { 92, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 92", 1.2m, 20 },
                    { 93, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 93", 1.2m, 20 },
                    { 94, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 94", 1.2m, 20 },
                    { 95, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 95", 1.2m, 20 },
                    { 96, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 96", 1.2m, 20 },
                    { 97, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 97", 1.2m, 20 },
                    { 98, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 98", 1.2m, 20 },
                    { 99, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 99", 1.2m, 20 },
                    { 100, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 100", 1.2m, 20 },
                    { 101, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 101", 1.2m, 20 },
                    { 102, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 102", 1.2m, 20 },
                    { 103, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 103", 1.2m, 20 },
                    { 104, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 104", 1.2m, 20 },
                    { 105, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 105", 1.2m, 20 },
                    { 106, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 106", 1.2m, 20 },
                    { 107, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 107", 1.2m, 20 },
                    { 108, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 108", 1.2m, 20 },
                    { 109, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 109", 1.2m, 20 },
                    { 110, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 110", 1.2m, 20 },
                    { 111, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 111", 1.2m, 20 },
                    { 112, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 112", 1.2m, 20 },
                    { 113, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 113", 1.2m, 20 },
                    { 114, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 114", 1.2m, 20 },
                    { 115, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 115", 1.2m, 20 },
                    { 116, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 116", 1.2m, 20 },
                    { 117, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 117", 1.2m, 20 },
                    { 118, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 118", 1.2m, 20 },
                    { 119, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 119", 1.2m, 20 },
                    { 120, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 120", 1.2m, 20 },
                    { 121, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 121", 1.2m, 20 },
                    { 122, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 122", 1.2m, 20 },
                    { 123, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 123", 1.2m, 20 },
                    { 124, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 124", 1.2m, 20 },
                    { 125, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 125", 1.2m, 20 },
                    { 126, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 126", 1.2m, 20 },
                    { 127, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 127", 1.2m, 20 },
                    { 128, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 128", 1.2m, 20 },
                    { 129, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 129", 1.2m, 20 },
                    { 130, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 130", 1.2m, 20 },
                    { 131, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 131", 1.2m, 20 },
                    { 132, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 132", 1.2m, 20 },
                    { 133, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 133", 1.2m, 20 },
                    { 134, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 134", 1.2m, 20 },
                    { 135, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 135", 1.2m, 20 },
                    { 136, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 136", 1.2m, 20 },
                    { 137, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 137", 1.2m, 20 },
                    { 138, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 138", 1.2m, 20 },
                    { 139, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 139", 1.2m, 20 },
                    { 140, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 140", 1.2m, 20 },
                    { 141, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 141", 1.2m, 20 },
                    { 142, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 142", 1.2m, 20 },
                    { 143, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 143", 1.2m, 20 },
                    { 144, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 144", 1.2m, 20 },
                    { 145, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 145", 1.2m, 20 },
                    { 146, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 146", 1.2m, 20 },
                    { 147, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 147", 1.2m, 20 },
                    { 148, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 148", 1.2m, 20 },
                    { 149, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 149", 1.2m, 20 },
                    { 150, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 150", 1.2m, 20 },
                    { 151, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 151", 1.2m, 20 },
                    { 152, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 152", 1.2m, 20 },
                    { 153, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 153", 1.2m, 20 },
                    { 154, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 154", 1.2m, 20 },
                    { 155, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 155", 1.2m, 20 },
                    { 156, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 156", 1.2m, 20 },
                    { 157, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 157", 1.2m, 20 },
                    { 158, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 158", 1.2m, 20 },
                    { 159, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 159", 1.2m, 20 },
                    { 160, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 160", 1.2m, 20 },
                    { 161, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 161", 1.2m, 20 },
                    { 162, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 162", 1.2m, 20 },
                    { 163, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 163", 1.2m, 20 },
                    { 164, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 164", 1.2m, 20 },
                    { 165, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 165", 1.2m, 20 },
                    { 166, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 166", 1.2m, 20 },
                    { 167, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 167", 1.2m, 20 },
                    { 168, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 168", 1.2m, 20 },
                    { 169, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 169", 1.2m, 20 },
                    { 170, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 170", 1.2m, 20 },
                    { 171, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 171", 1.2m, 20 },
                    { 172, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 172", 1.2m, 20 },
                    { 173, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 173", 1.2m, 20 },
                    { 174, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 174", 1.2m, 20 },
                    { 175, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 175", 1.2m, 20 },
                    { 176, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 176", 1.2m, 20 },
                    { 177, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 177", 1.2m, 20 },
                    { 178, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 178", 1.2m, 20 },
                    { 179, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 179", 1.2m, 20 },
                    { 180, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 180", 1.2m, 20 },
                    { 181, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 181", 1.2m, 20 },
                    { 182, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 182", 1.2m, 20 },
                    { 183, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 183", 1.2m, 20 },
                    { 184, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 184", 1.2m, 20 },
                    { 185, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 185", 1.2m, 20 },
                    { 186, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 186", 1.2m, 20 },
                    { 187, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 187", 1.2m, 20 },
                    { 188, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 188", 1.2m, 20 },
                    { 189, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 189", 1.2m, 20 },
                    { 190, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 190", 1.2m, 20 },
                    { 191, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 191", 1.2m, 20 },
                    { 192, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 192", 1.2m, 20 },
                    { 193, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 193", 1.2m, 20 },
                    { 194, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 194", 1.2m, 20 },
                    { 195, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 195", 1.2m, 20 },
                    { 196, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 196", 1.2m, 20 },
                    { 197, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 197", 1.2m, 20 },
                    { 198, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 198", 1.2m, 20 },
                    { 199, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 199", 1.2m, 20 },
                    { 200, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 200", 1.2m, 20 },
                    { 201, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 201", 1.2m, 20 },
                    { 202, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 202", 1.2m, 20 },
                    { 203, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 203", 1.2m, 20 },
                    { 204, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 204", 1.2m, 20 },
                    { 205, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 205", 1.2m, 20 },
                    { 206, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 206", 1.2m, 20 },
                    { 207, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 207", 1.2m, 20 },
                    { 208, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 208", 1.2m, 20 },
                    { 209, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 209", 1.2m, 20 },
                    { 210, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 210", 1.2m, 20 },
                    { 211, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 211", 1.2m, 20 },
                    { 212, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 212", 1.2m, 20 },
                    { 213, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 213", 1.2m, 20 },
                    { 214, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 214", 1.2m, 20 },
                    { 215, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 215", 1.2m, 20 },
                    { 216, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 216", 1.2m, 20 },
                    { 217, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 217", 1.2m, 20 },
                    { 218, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 218", 1.2m, 20 },
                    { 219, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 219", 1.2m, 20 },
                    { 220, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 220", 1.2m, 20 },
                    { 221, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 221", 1.2m, 20 },
                    { 222, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 222", 1.2m, 20 },
                    { 223, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 223", 1.2m, 20 },
                    { 224, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 224", 1.2m, 20 },
                    { 225, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 225", 1.2m, 20 },
                    { 226, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 226", 1.2m, 20 },
                    { 227, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 227", 1.2m, 20 },
                    { 228, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 228", 1.2m, 20 },
                    { 229, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 229", 1.2m, 20 },
                    { 230, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 230", 1.2m, 20 },
                    { 231, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 231", 1.2m, 20 },
                    { 232, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 232", 1.2m, 20 },
                    { 233, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 233", 1.2m, 20 },
                    { 234, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 234", 1.2m, 20 },
                    { 235, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 235", 1.2m, 20 },
                    { 236, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 236", 1.2m, 20 },
                    { 237, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 237", 1.2m, 20 },
                    { 238, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 238", 1.2m, 20 },
                    { 239, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 239", 1.2m, 20 },
                    { 240, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 240", 1.2m, 20 },
                    { 241, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 241", 1.2m, 20 },
                    { 242, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 242", 1.2m, 20 },
                    { 243, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 243", 1.2m, 20 },
                    { 244, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 244", 1.2m, 20 },
                    { 245, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 245", 1.2m, 20 },
                    { 246, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 246", 1.2m, 20 },
                    { 247, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 247", 1.2m, 20 },
                    { 248, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 248", 1.2m, 20 },
                    { 249, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 249", 1.2m, 20 },
                    { 250, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 250", 1.2m, 20 },
                    { 251, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 251", 1.2m, 20 },
                    { 252, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 252", 1.2m, 20 },
                    { 253, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 253", 1.2m, 20 },
                    { 254, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 254", 1.2m, 20 },
                    { 255, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 255", 1.2m, 20 },
                    { 256, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 256", 1.2m, 20 },
                    { 257, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 257", 1.2m, 20 },
                    { 258, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 258", 1.2m, 20 },
                    { 259, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 259", 1.2m, 20 },
                    { 260, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 260", 1.2m, 20 },
                    { 261, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 261", 1.2m, 20 },
                    { 262, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 262", 1.2m, 20 },
                    { 263, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 263", 1.2m, 20 },
                    { 264, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 264", 1.2m, 20 },
                    { 265, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 265", 1.2m, 20 },
                    { 266, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 266", 1.2m, 20 },
                    { 267, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 267", 1.2m, 20 },
                    { 268, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 268", 1.2m, 20 },
                    { 269, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 269", 1.2m, 20 },
                    { 270, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 270", 1.2m, 20 },
                    { 271, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 271", 1.2m, 20 },
                    { 272, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 272", 1.2m, 20 },
                    { 273, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 273", 1.2m, 20 },
                    { 274, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 274", 1.2m, 20 },
                    { 275, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 275", 1.2m, 20 },
                    { 276, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 276", 1.2m, 20 },
                    { 277, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 277", 1.2m, 20 },
                    { 278, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 278", 1.2m, 20 },
                    { 279, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 279", 1.2m, 20 },
                    { 280, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 280", 1.2m, 20 },
                    { 281, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 281", 1.2m, 20 },
                    { 282, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 282", 1.2m, 20 },
                    { 283, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 283", 1.2m, 20 },
                    { 284, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 284", 1.2m, 20 },
                    { 285, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 285", 1.2m, 20 },
                    { 286, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 286", 1.2m, 20 },
                    { 287, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 287", 1.2m, 20 },
                    { 288, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 288", 1.2m, 20 },
                    { 289, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 289", 1.2m, 20 },
                    { 290, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 290", 1.2m, 20 },
                    { 291, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 291", 1.2m, 20 },
                    { 292, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 292", 1.2m, 20 },
                    { 293, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 293", 1.2m, 20 },
                    { 294, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 294", 1.2m, 20 },
                    { 295, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 295", 1.2m, 20 },
                    { 296, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 296", 1.2m, 20 },
                    { 297, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 297", 1.2m, 20 },
                    { 298, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 298", 1.2m, 20 },
                    { 299, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 299", 1.2m, 20 },
                    { 300, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 300", 1.2m, 20 },
                    { 301, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 301", 1.2m, 20 },
                    { 302, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 302", 1.2m, 20 },
                    { 303, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 303", 1.2m, 20 },
                    { 304, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 304", 1.2m, 20 },
                    { 305, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 305", 1.2m, 20 },
                    { 306, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 306", 1.2m, 20 },
                    { 307, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 307", 1.2m, 20 },
                    { 308, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 308", 1.2m, 20 },
                    { 309, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 309", 1.2m, 20 },
                    { 310, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 310", 1.2m, 20 },
                    { 311, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 311", 1.2m, 20 },
                    { 312, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 312", 1.2m, 20 },
                    { 313, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 313", 1.2m, 20 },
                    { 314, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 314", 1.2m, 20 },
                    { 315, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 315", 1.2m, 20 },
                    { 316, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 316", 1.2m, 20 },
                    { 317, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 317", 1.2m, 20 },
                    { 318, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 318", 1.2m, 20 },
                    { 319, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 319", 1.2m, 20 },
                    { 320, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 320", 1.2m, 20 },
                    { 321, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 321", 1.2m, 20 },
                    { 322, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 322", 1.2m, 20 },
                    { 323, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 323", 1.2m, 20 },
                    { 324, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 324", 1.2m, 20 },
                    { 325, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 325", 1.2m, 20 },
                    { 326, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 326", 1.2m, 20 },
                    { 327, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 327", 1.2m, 20 },
                    { 328, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 328", 1.2m, 20 },
                    { 329, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 329", 1.2m, 20 },
                    { 330, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 330", 1.2m, 20 },
                    { 331, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 331", 1.2m, 20 },
                    { 332, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 332", 1.2m, 20 },
                    { 333, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 333", 1.2m, 20 },
                    { 334, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 334", 1.2m, 20 },
                    { 335, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 335", 1.2m, 20 },
                    { 336, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 336", 1.2m, 20 },
                    { 337, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 337", 1.2m, 20 },
                    { 338, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 338", 1.2m, 20 },
                    { 339, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 339", 1.2m, 20 },
                    { 340, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 340", 1.2m, 20 },
                    { 341, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 341", 1.2m, 20 },
                    { 342, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 342", 1.2m, 20 },
                    { 343, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 343", 1.2m, 20 },
                    { 344, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 344", 1.2m, 20 },
                    { 345, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 345", 1.2m, 20 },
                    { 346, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 346", 1.2m, 20 },
                    { 347, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 347", 1.2m, 20 },
                    { 348, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 348", 1.2m, 20 },
                    { 349, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 349", 1.2m, 20 },
                    { 350, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 350", 1.2m, 20 },
                    { 351, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 351", 1.2m, 20 },
                    { 352, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 352", 1.2m, 20 },
                    { 353, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 353", 1.2m, 20 },
                    { 354, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 354", 1.2m, 20 },
                    { 355, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 355", 1.2m, 20 },
                    { 356, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 356", 1.2m, 20 },
                    { 357, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 357", 1.2m, 20 },
                    { 358, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 358", 1.2m, 20 },
                    { 359, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 359", 1.2m, 20 },
                    { 360, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 360", 1.2m, 20 },
                    { 361, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 361", 1.2m, 20 },
                    { 362, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 362", 1.2m, 20 },
                    { 363, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 363", 1.2m, 20 },
                    { 364, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 364", 1.2m, 20 },
                    { 365, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 365", 1.2m, 20 },
                    { 366, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 366", 1.2m, 20 },
                    { 367, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 367", 1.2m, 20 },
                    { 368, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 368", 1.2m, 20 },
                    { 369, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 369", 1.2m, 20 },
                    { 370, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 370", 1.2m, 20 },
                    { 371, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 371", 1.2m, 20 },
                    { 372, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 372", 1.2m, 20 },
                    { 373, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 373", 1.2m, 20 },
                    { 374, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 374", 1.2m, 20 },
                    { 375, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 375", 1.2m, 20 },
                    { 376, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 376", 1.2m, 20 },
                    { 377, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 377", 1.2m, 20 },
                    { 378, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 378", 1.2m, 20 },
                    { 379, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 379", 1.2m, 20 },
                    { 380, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 380", 1.2m, 20 },
                    { 381, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 381", 1.2m, 20 },
                    { 382, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 382", 1.2m, 20 },
                    { 383, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 383", 1.2m, 20 },
                    { 384, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 384", 1.2m, 20 },
                    { 385, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 385", 1.2m, 20 },
                    { 386, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 386", 1.2m, 20 },
                    { 387, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 387", 1.2m, 20 },
                    { 388, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 388", 1.2m, 20 },
                    { 389, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 389", 1.2m, 20 },
                    { 390, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 390", 1.2m, 20 },
                    { 391, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 391", 1.2m, 20 },
                    { 392, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 392", 1.2m, 20 },
                    { 393, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 393", 1.2m, 20 },
                    { 394, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 394", 1.2m, 20 },
                    { 395, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 395", 1.2m, 20 },
                    { 396, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 396", 1.2m, 20 },
                    { 397, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 397", 1.2m, 20 },
                    { 398, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 398", 1.2m, 20 },
                    { 399, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 399", 1.2m, 20 },
                    { 400, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 400", 1.2m, 20 },
                    { 401, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 401", 1.2m, 20 },
                    { 402, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 402", 1.2m, 20 },
                    { 403, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 403", 1.2m, 20 },
                    { 404, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 404", 1.2m, 20 },
                    { 405, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 405", 1.2m, 20 },
                    { 406, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 406", 1.2m, 20 },
                    { 407, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 407", 1.2m, 20 },
                    { 408, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 408", 1.2m, 20 },
                    { 409, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 409", 1.2m, 20 },
                    { 410, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 410", 1.2m, 20 },
                    { 411, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 411", 1.2m, 20 },
                    { 412, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 412", 1.2m, 20 },
                    { 413, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 413", 1.2m, 20 },
                    { 414, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 414", 1.2m, 20 },
                    { 415, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 415", 1.2m, 20 },
                    { 416, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 416", 1.2m, 20 },
                    { 417, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 417", 1.2m, 20 },
                    { 418, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 418", 1.2m, 20 },
                    { 419, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 419", 1.2m, 20 },
                    { 420, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 420", 1.2m, 20 },
                    { 421, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 421", 1.2m, 20 },
                    { 422, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 422", 1.2m, 20 },
                    { 423, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 423", 1.2m, 20 },
                    { 424, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 424", 1.2m, 20 },
                    { 425, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 425", 1.2m, 20 },
                    { 426, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 426", 1.2m, 20 },
                    { 427, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 427", 1.2m, 20 },
                    { 428, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 428", 1.2m, 20 },
                    { 429, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 429", 1.2m, 20 },
                    { 430, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 430", 1.2m, 20 },
                    { 431, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 431", 1.2m, 20 },
                    { 432, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 432", 1.2m, 20 },
                    { 433, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 433", 1.2m, 20 },
                    { 434, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 434", 1.2m, 20 },
                    { 435, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 435", 1.2m, 20 },
                    { 436, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 436", 1.2m, 20 },
                    { 437, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 437", 1.2m, 20 },
                    { 438, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 438", 1.2m, 20 },
                    { 439, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 439", 1.2m, 20 },
                    { 440, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 440", 1.2m, 20 },
                    { 441, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 441", 1.2m, 20 },
                    { 442, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 442", 1.2m, 20 },
                    { 443, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 443", 1.2m, 20 },
                    { 444, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 444", 1.2m, 20 },
                    { 445, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 445", 1.2m, 20 },
                    { 446, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 446", 1.2m, 20 },
                    { 447, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 447", 1.2m, 20 },
                    { 448, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 448", 1.2m, 20 },
                    { 449, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 449", 1.2m, 20 },
                    { 450, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 450", 1.2m, 20 },
                    { 451, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 451", 1.2m, 20 },
                    { 452, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 452", 1.2m, 20 },
                    { 453, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 453", 1.2m, 20 },
                    { 454, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 454", 1.2m, 20 },
                    { 455, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 455", 1.2m, 20 },
                    { 456, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 456", 1.2m, 20 },
                    { 457, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 457", 1.2m, 20 },
                    { 458, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 458", 1.2m, 20 },
                    { 459, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 459", 1.2m, 20 },
                    { 460, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 460", 1.2m, 20 },
                    { 461, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 461", 1.2m, 20 },
                    { 462, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 462", 1.2m, 20 },
                    { 463, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 463", 1.2m, 20 },
                    { 464, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 464", 1.2m, 20 },
                    { 465, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 465", 1.2m, 20 },
                    { 466, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 466", 1.2m, 20 },
                    { 467, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 467", 1.2m, 20 },
                    { 468, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 468", 1.2m, 20 },
                    { 469, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 469", 1.2m, 20 },
                    { 470, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 470", 1.2m, 20 },
                    { 471, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 471", 1.2m, 20 },
                    { 472, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 472", 1.2m, 20 },
                    { 473, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 473", 1.2m, 20 },
                    { 474, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 474", 1.2m, 20 },
                    { 475, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 475", 1.2m, 20 },
                    { 476, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 476", 1.2m, 20 },
                    { 477, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 477", 1.2m, 20 },
                    { 478, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 478", 1.2m, 20 },
                    { 479, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 479", 1.2m, 20 },
                    { 480, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 480", 1.2m, 20 },
                    { 481, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 481", 1.2m, 20 },
                    { 482, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 482", 1.2m, 20 },
                    { 483, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 483", 1.2m, 20 },
                    { 484, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 484", 1.2m, 20 },
                    { 485, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 485", 1.2m, 20 },
                    { 486, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 486", 1.2m, 20 },
                    { 487, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 487", 1.2m, 20 },
                    { 488, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 488", 1.2m, 20 },
                    { 489, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 489", 1.2m, 20 },
                    { 490, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 490", 1.2m, 20 },
                    { 491, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 491", 1.2m, 20 },
                    { 492, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 492", 1.2m, 20 },
                    { 493, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 493", 1.2m, 20 },
                    { 494, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 494", 1.2m, 20 },
                    { 495, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 495", 1.2m, 20 },
                    { 496, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 496", 1.2m, 20 },
                    { 497, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 497", 1.2m, 20 },
                    { 498, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 498", 1.2m, 20 },
                    { 499, 2, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Item 499", 1.2m, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ArticleId",
                table: "OrderItems",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
