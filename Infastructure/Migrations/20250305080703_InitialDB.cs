using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelYear = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ValidDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Cvv = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_CreditCards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentStartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentEndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { new Guid("29b563dd-51ca-41a9-b70a-c116d1a49236"), "BMW" },
                    { new Guid("3593d41d-ad87-467b-a2fc-deefe77099df"), "Audi" }
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "CardId", "CardNumber", "CardUser", "CustomerId", "Cvv", "ValidDate" },
                values: new object[,]
                {
                    { new Guid("91c79146-4247-482b-9c6c-224dee8035e3"), "1234123412341234", "Erim", new Guid("00000000-0000-0000-0000-000000000000"), "123", "12/25" },
                    { new Guid("b820905a-f5d4-4ec0-873c-e0f66fdeac8d"), "1111111111111111", "Erim", new Guid("00000000-0000-0000-0000-000000000000"), "124", "12/25" },
                    { new Guid("cf55599f-d880-4723-ab05-fe2948086c62"), "4321432143214321", "Mert", new Guid("00000000-0000-0000-0000-000000000000"), "321", "11/25" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerEmail", "CustomerName" },
                values: new object[,]
                {
                    { new Guid("9cafddf3-8cde-400f-b9f3-7bdcf76f6198"), "akdjasdajkdsaj@gmail.com", "Mert" },
                    { new Guid("cc358324-5c06-4409-ac02-d4fb3017735d"), "skjdfldskfj@gmail.com", "Erim" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "BrandId", "CarName", "DailyPrice", "Description", "ModelYear" },
                values: new object[,]
                {
                    { new Guid("17d6d4c8-afc8-4689-bea6-671860186dd5"), new Guid("29b563dd-51ca-41a9-b70a-c116d1a49236"), "320i", 20.00m, "Good sport car for young", 2022 },
                    { new Guid("b6bec2ed-6387-4c2d-97df-8dd2d79d0e99"), new Guid("3593d41d-ad87-467b-a2fc-deefe77099df"), "A5 45 TFSI", 25.00m, "Good Family Sport Car", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "RentId", "CarId", "CustomerId", "RentEndDateTime", "RentStartDateTime", "RentStatus" },
                values: new object[] { new Guid("e591e122-9a1f-4680-8154-c1f68c4a563b"), new Guid("b6bec2ed-6387-4c2d-97df-8dd2d79d0e99"), new Guid("cc358324-5c06-4409-ac02-d4fb3017735d"), new DateTime(2025, 3, 6, 11, 7, 2, 702, DateTimeKind.Local).AddTicks(6313), new DateTime(2025, 3, 4, 11, 7, 2, 701, DateTimeKind.Local).AddTicks(4082), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CustomerId",
                table: "CreditCards",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
