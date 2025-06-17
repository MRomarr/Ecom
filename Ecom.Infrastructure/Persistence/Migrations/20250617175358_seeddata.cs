using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecom.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3f4c5b12-8f6d-43ea-a1a0-2e9e1c5a7432"), "Electronics" },
                    { new Guid("b2f2c2d2-e2f2-4a2b-9c2d-2e2f2a2b2c2d"), "Books" },
                    { new Guid("c3a3d3e3-f3a3-4b3c-0d3e-3f3a3b3c3d3e"), "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"), new Guid("3f4c5b12-8f6d-43ea-a1a0-2e9e1c5a7432"), "Ergonomic office chair with lumbar support.", "Office Chair", 199.99m, 20 },
                    { new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"), new Guid("3f4c5b12-8f6d-43ea-a1a0-2e9e1c5a7432"), "Modern dining table made of solid wood.", "Dining Table", 499.99m, 10 },
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), new Guid("b2f2c2d2-e2f2-4a2b-9c2d-2e2f2a2b2c2d"), "Latest model smartphone with advanced features.", "Smartphone", 699.99m, 50 },
                    { new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"), new Guid("c3a3d3e3-f3a3-4b3c-0d3e-3f3a3b3c3d3e"), "High-performance laptop for gaming and work.", "Laptop", 1299.99m, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2f2c2d2-e2f2-4a2b-9c2d-2e2f2a2b2c2d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c3a3d3e3-f3a3-4b3c-0d3e-3f3a3b3c3d3e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3f4c5b12-8f6d-43ea-a1a0-2e9e1c5a7432"));
        }
    }
}
