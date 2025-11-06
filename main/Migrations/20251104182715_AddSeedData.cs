using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace main.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Description", "IsAvailable", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, null, true, "Slim Gallon - Refill", 25.00m, "Refill" },
                    { 2, null, true, "Round Gallon - Refill", 30.00m, "Refill" },
                    { 3, null, true, "Slim Gallon - Purchase New", 200.00m, "Purchase" },
                    { 4, null, true, "Round Gallon - Purchase New", 250.00m, "Purchase" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "ContactNumber", "DateCreated", "Email", "FullName", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, "123 Admin St, Water Station HQ", "09123456789", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@wsoa.com", "Admin User", "AQAAAAIAAYagAAAAEI/rU6h10NJmN9iVARyMhPDb0dWTzKqRVCbJFXjNqJ2mXmHBSsE2YqLq4WvSfYdDkQ==", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
