using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The current stock quantity of the product.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 25, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(831), "/images/Products/a974b4f3-3929-44ca-bb6d-b9c3a91870cb.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 24, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(865), "/images/Products/b19bfbd0-793c-40fd-a5eb-f6612430b704.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 23, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1010), "/images/Products/5f88c123-7f4d-400d-a186-2cec6601bbe2.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1023), "/images/Products/8c05fbd4-887d-4ffb-bce0-35f087a19576.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1033), "/images/Products/1ebf3998-c63e-4faf-9b4d-4d8e09cf7736.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1049), "/images/Products/12ee9912-4de4-431d-a763-f4a38ec8a12f.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1060), "/images/Products/026e8a71-9632-4c60-812a-fe32808f0fbd.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1069), "/images/Products/3261696c-d183-46b3-9e2f-224302843264.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1078), "/images/Products/2692e08d-98de-4809-bf25-dc746e7ec8fe.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1094), "/images/Products/c78d2829-5c22-4016-a9fb-8141eba3e4b3.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1110), "/images/Products/ebad3203-9bcf-4107-8ae1-4d2556dd977e.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1120), "/images/Products/4f402d33-8859-4154-9b20-cebccf20b791.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1216), "/images/Products/fd3d9c0f-8f38-4464-b6a0-9d87485844b1.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1227), "/images/Products/e19fdecc-730a-4787-8bec-f852fd68c0ce.png", 0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image", "StockQuantity" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1237), "/images/Products/576ef3fc-777f-457a-ac78-5f338f6d40b2.png", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 23, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7799), "/images/Products/59c745d5-ee64-40b6-8377-afff8012b8cc.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7831), "/images/Products/0b1a81bb-c611-4c43-88c1-c10a78a8166f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7899), "/images/Products/cc8f288d-2497-4dac-adf2-d5506bce79a8.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7906), "/images/Products/bf5648c6-faf6-402c-b901-1fa93d7b855a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7912), "/images/Products/cd682cb8-c42e-4b1a-a64a-e6f31c958c44.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7922), "/images/Products/dbcb6d3d-c502-4208-8b9f-442f5a0cac5d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7928), "/images/Products/ccb3f8d6-687b-43e6-8850-2e37ce397bdc.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7934), "/images/Products/900bb5c0-06ef-4058-a947-2226be78a660.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7940), "/images/Products/ed3b7efc-02ea-492d-b329-eb67cc8de79c.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7955), "/images/Products/e2908cd4-5fe3-42ca-9e1a-fcbd90cc7486.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7961), "/images/Products/469adf70-f599-4961-80e4-a1c10f2524c2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7967), "/images/Products/6b97a061-c604-4166-b3ad-3e9d8e782eaa.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(7973), "/images/Products/b2ae2821-2d20-4b20-b035-27e8d45a42c1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(8032), "/images/Products/d3163616-0ca3-412e-b824-8b40c598a2ef.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 16, 46, 33, 129, DateTimeKind.Utc).AddTicks(8038), "/images/Products/e1e3cae6-c62e-4827-b49e-b86861b4c00e.png" });
        }
    }
}
