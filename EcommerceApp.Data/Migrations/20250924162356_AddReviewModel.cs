using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "Rating given to the product."),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Comment from the user about the product."),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date when the review was created."),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier of the user who wrote the review."),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the product for which the review is written.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
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
                values: new object[] { new DateTime(2025, 9, 23, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4406), "/images/Products/92ac06be-250f-4cac-88de-1ddb51dc5a41.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4460), "/images/Products/0a0aa982-c440-45d2-aeb1-c0b773830311.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4466), "/images/Products/2f1bda53-b21d-4471-9270-7557323df4c8.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4472), "/images/Products/42a2507f-93a7-4a06-8ec8-40c26ef29592.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4488), "/images/Products/98fd3fcf-a020-4ad4-99bd-cc84d3ccfde5.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4496), "/images/Products/02eab3f9-43a6-4ee6-96ac-6f651ce05df1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4502), "/images/Products/0aa8de40-64f5-42ae-9d05-4ad3b8a5d912.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4508), "/images/Products/ba2335a9-304c-4276-9b4b-c2abdbec0a78.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4513), "/images/Products/98466c75-c585-4afa-bbc2-3b2c1409d60d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4522), "/images/Products/d414a64e-6725-4fd6-bc79-ff5523ecfbba.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4528), "/images/Products/e1c3da6d-986a-423e-a74c-38c62f32e262.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4534), "/images/Products/38cb82ec-020b-4633-b04a-4d862474a22a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4642), "/images/Products/1ff07575-f529-450a-8b40-d1c01dcf6621.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4648), "/images/Products/21704095-aea0-43b1-8e07-2cd07434bec6.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 16, 23, 54, 469, DateTimeKind.Utc).AddTicks(4654), "/images/Products/1d3afdcf-1c3d-42c0-8be8-fd57f1ea878b.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 23, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5774), "/images/Products/6750ca1d-58ac-472b-9b50-3702be70b831.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5800), "/images/Products/4ed75afe-cef5-4fa2-a500-117918ae26f3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5807), "/images/Products/b31c51e8-873a-47f8-a573-977d275779af.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5813), "/images/Products/fe7b718e-f762-443f-9789-7e0deada548a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5819), "/images/Products/4830ddcf-c97e-4611-b88a-69c7ef5f0bf4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5827), "/images/Products/e47187b2-a1c1-49b4-b163-07d234cf9d5d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5841), "/images/Products/657f89bd-0682-4f0b-8e79-492b74d7e927.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5902), "/images/Products/17216de9-0f74-431b-9a41-0e0a333557d0.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5909), "/images/Products/acdb3ebf-34d9-4ac4-8f92-814124edd32b.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5920), "/images/Products/783a7f96-032d-487e-874e-dd8441df80a2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5926), "/images/Products/2e7261ce-20a4-407d-9b58-707bfaffe6b4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5932), "/images/Products/a928418a-9f1f-4f48-9fe6-ff4e68d5db55.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5937), "/images/Products/1a906fc7-33c6-43f1-bb1b-483f7b4d21aa.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5943), "/images/Products/00cac1b9-9aab-4095-bb79-2efb0f06b366.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5953), "/images/Products/2d96d500-fe4e-4a5b-9a6b-212ba4f3e6ad.png" });
        }
    }
}
