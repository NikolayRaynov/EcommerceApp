using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: false, comment: "URL of the image."),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description of the image."),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the product to which the image belongs.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(1994), "/images/Products/4aaaafb3-a361-4b24-96f1-ffc69314e9bc.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2030), "/images/Products/0a232654-dbb1-4412-8d41-caae319d2c77.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2040), "/images/Products/e2bb73ea-f15c-4b05-9ad6-8c3fe55693f0.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2067), "/images/Products/28f28930-9800-44df-bcf4-4c396dc2c652.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2078), "/images/Products/3bc9269d-4067-4e9b-9390-40df5cba342c.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2093), "/images/Products/4e106c2d-79d7-480d-820e-e893d1073a73.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2103), "/images/Products/51e5bf52-b556-48c4-9fc3-24c01ce7247c.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2114), "/images/Products/7693a0c7-c753-4ab5-9e84-5734bbd9b2d0.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2124), "/images/Products/c2cda0a3-591a-4e76-9793-ba110dfe096f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2140), "/images/Products/6fe071ba-dffc-49e6-87d1-04cdecd3731c.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2292), "/images/Products/4331ca90-626c-4b20-99ea-9c3262201de6.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2309), "/images/Products/b3b8c3dc-e696-461b-a50e-adb6c299f653.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2319), "/images/Products/7baf6c1b-f9ea-4b69-9d77-7c751af0512f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2330), "/images/Products/2767ddba-3689-49ea-9c3d-3a660b9cf1e8.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 8, 16, 17, 51, 797, DateTimeKind.Utc).AddTicks(2340), "/images/Products/a21b71cc-2e11-4704-a7b5-6fd00f279032.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5483), "/images/Products/f871244d-cfb8-4742-a8fb-f4552b71714d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5517), "/images/Products/dd802a7d-2080-4eeb-9d27-42ace5345e2f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5527), "/images/Products/2edfdba0-1cb7-479f-aa7a-299a65b7dc76.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5536), "/images/Products/491e796c-0bc5-4a23-b800-97f12c90ee56.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5544), "/images/Products/8321090d-2190-43cb-ab9b-78304c3cd4f8.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 8, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5576), "/images/Products/7d5eb686-84e1-4d12-aca5-b68779abf536.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 7, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5585), "/images/Products/decf664a-ee22-47d7-9dbc-ee2d6e6220ce.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 6, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5594), "/images/Products/63cfbf4c-8b1a-4e7b-b795-1ec7016c24c9.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 5, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5601), "/images/Products/979ebda9-3b40-49f4-b7af-22428c1099c0.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 4, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5772), "/images/Products/66b05edf-56bc-4ff6-aca3-1a7f3406d47d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 3, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5782), "/images/Products/6a8eac93-bfe0-49d6-a541-2b17edc32dae.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 2, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5791), "/images/Products/fd0b0f9f-03c8-4e33-b11d-e492fdc41f95.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 1, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5801), "/images/Products/075876ae-5c2d-442a-814d-e568ea15559a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 31, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5815), "/images/Products/2679a9d7-d26c-4031-9fc6-63b4388d368c.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 30, 14, 14, 42, 179, DateTimeKind.Utc).AddTicks(5824), "/images/Products/22e47208-9b1a-4f99-8bb8-18ea69b1fd42.png" });
        }
    }
}
