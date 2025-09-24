using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoriteProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoriteProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier of the user who marked the product as favorite.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 23, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5774), null, "/images/Products/6750ca1d-58ac-472b-9b50-3702be70b831.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5800), null, "/images/Products/4ed75afe-cef5-4fa2-a500-117918ae26f3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5807), null, "/images/Products/b31c51e8-873a-47f8-a573-977d275779af.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5813), null, "/images/Products/fe7b718e-f762-443f-9789-7e0deada548a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5819), null, "/images/Products/4830ddcf-c97e-4611-b88a-69c7ef5f0bf4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5827), null, "/images/Products/e47187b2-a1c1-49b4-b163-07d234cf9d5d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5841), null, "/images/Products/657f89bd-0682-4f0b-8e79-492b74d7e927.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5902), null, "/images/Products/17216de9-0f74-431b-9a41-0e0a333557d0.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5909), null, "/images/Products/acdb3ebf-34d9-4ac4-8f92-814124edd32b.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5920), null, "/images/Products/783a7f96-032d-487e-874e-dd8441df80a2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5926), null, "/images/Products/2e7261ce-20a4-407d-9b58-707bfaffe6b4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5932), null, "/images/Products/a928418a-9f1f-4f48-9fe6-ff4e68d5db55.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5937), null, "/images/Products/1a906fc7-33c6-43f1-bb1b-483f7b4d21aa.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5943), null, "/images/Products/00cac1b9-9aab-4095-bb79-2efb0f06b366.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "FavoriteProductId", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 16, 10, 41, 645, DateTimeKind.Utc).AddTicks(5953), null, "/images/Products/2d96d500-fe4e-4a5b-9a6b-212ba4f3e6ad.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavoriteProductId",
                table: "Products",
                column: "FavoriteProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_UserId",
                table: "FavoriteProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FavoriteProducts_FavoriteProductId",
                table: "Products",
                column: "FavoriteProductId",
                principalTable: "FavoriteProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_FavoriteProducts_FavoriteProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FavoriteProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_FavoriteProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FavoriteProductId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(6716), "/images/Products/03bb1d34-6292-4183-b8ab-50ea9d818d86.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(6774), "/images/Products/e373d292-d2f6-44eb-b7a1-9926c88418e4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(6796), "/images/Products/c4be995e-aa55-4fb0-99a9-f49f8d87ace4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(6819), "/images/Products/1b563f18-9b44-4fc2-9ee3-bfc2e955b6ad.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(6847), "/images/Products/2c14cbf2-ba94-4e1c-a837-7d986d9cca7d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7046), "/images/Products/f136b0d3-4f1d-4b47-abd5-c6f0ef186f2f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7072), "/images/Products/7dc608a0-8a4c-46c3-8576-4d6dadffd45a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7097), "/images/Products/1deeb74c-9970-42de-a16b-c5fcbdd2df85.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7129), "/images/Products/dc6d27b5-effa-4da0-ba77-bca8d098851e.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7167), "/images/Products/a8559272-8fb2-426f-903d-a1daa71c06c4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7193), "/images/Products/83c581f8-4422-403d-9cf8-189f4b8629a5.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7214), "/images/Products/52685adb-8c7c-4825-b0cb-db4a789c4a70.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7237), "/images/Products/da114601-12f4-4430-ae7d-28ff8740f807.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7259), "/images/Products/1fa212bf-9c4b-4cba-9653-7c9c85d7cb6a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 8, 16, 37, 53, 832, DateTimeKind.Utc).AddTicks(7280), "/images/Products/7ccaae2e-4540-4754-9808-7443ef261340.png" });
        }
    }
}
