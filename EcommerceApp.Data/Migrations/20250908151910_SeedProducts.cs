using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 7, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1633), "This is the description for Product 1. It's a high-quality product with excellent features.", "/images/Products/a464df14-3f5e-4173-9726-202c59be252c.png", "Product Name 1", 12.50m },
                    { 2, new DateTime(2025, 9, 6, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1671), "This is the description for Product 2. It's a high-quality product with excellent features.", "/images/Products/91ae23f8-eeb1-4f18-8683-392312654cca.png", "Product Name 2", 15.00m },
                    { 3, new DateTime(2025, 9, 5, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1681), "This is the description for Product 3. It's a high-quality product with excellent features.", "/images/Products/3fd9937b-4b99-4e0b-a275-413363408fb5.png", "Product Name 3", 17.50m },
                    { 4, new DateTime(2025, 9, 4, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1705), "This is the description for Product 4. It's a high-quality product with excellent features.", "/images/Products/98cb029b-8ea2-4165-a166-e156a981ff7e.png", "Product Name 4", 20.00m },
                    { 5, new DateTime(2025, 9, 3, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1714), "This is the description for Product 5. It's a high-quality product with excellent features.", "/images/Products/307fb41d-eca5-4873-a006-0abf769b7456.png", "Product Name 5", 22.50m },
                    { 6, new DateTime(2025, 9, 2, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1730), "This is the description for Product 6. It's a high-quality product with excellent features.", "/images/Products/d8ff8901-23a5-41af-8c96-17f4dab06ccd.png", "Product Name 6", 25.00m },
                    { 7, new DateTime(2025, 9, 1, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1738), "This is the description for Product 7. It's a high-quality product with excellent features.", "/images/Products/a0532a05-d894-4cd7-a54c-fb3dd5c0aece.png", "Product Name 7", 27.50m },
                    { 8, new DateTime(2025, 8, 31, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1747), "This is the description for Product 8. It's a high-quality product with excellent features.", "/images/Products/43c4d90a-550b-490c-9b98-68226cec31ce.png", "Product Name 8", 30.00m },
                    { 9, new DateTime(2025, 8, 30, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1755), "This is the description for Product 9. It's a high-quality product with excellent features.", "/images/Products/725cf7c6-3811-4d0d-a2af-d7bbd770a2fa.png", "Product Name 9", 32.50m },
                    { 10, new DateTime(2025, 8, 29, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1793), "This is the description for Product 10. It's a high-quality product with excellent features.", "/images/Products/6882a5d9-f9d6-483a-8c8e-d0b78c54e706.png", "Product Name 10", 35.00m },
                    { 11, new DateTime(2025, 8, 28, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1802), "This is the description for Product 11. It's a high-quality product with excellent features.", "/images/Products/6cb1bf01-c4bb-41f5-bc4b-f2a26feb543a.png", "Product Name 11", 37.50m },
                    { 12, new DateTime(2025, 8, 27, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1815), "This is the description for Product 12. It's a high-quality product with excellent features.", "/images/Products/69aa8e35-15a0-4ac0-bf2d-60679a0e48de.png", "Product Name 12", 40.00m },
                    { 13, new DateTime(2025, 8, 26, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1823), "This is the description for Product 13. It's a high-quality product with excellent features.", "/images/Products/7fac8217-3d9f-4a37-9023-85e234ad7e0e.png", "Product Name 13", 42.50m },
                    { 14, new DateTime(2025, 8, 25, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1831), "This is the description for Product 14. It's a high-quality product with excellent features.", "/images/Products/9f7bc0c1-6d72-47ea-a4c1-59f5c3bbb546.png", "Product Name 14", 45.00m },
                    { 15, new DateTime(2025, 8, 24, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1840), "This is the description for Product 15. It's a high-quality product with excellent features.", "/images/Products/eacf612c-b805-467f-8e21-0063cd71282b.png", "Product Name 15", 47.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
