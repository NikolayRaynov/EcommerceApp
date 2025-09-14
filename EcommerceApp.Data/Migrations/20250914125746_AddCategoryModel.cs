using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false, comment: "Name of the category.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 13, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(353), "/images/Products/6b431372-c649-469f-b35e-8b4bb6026a3f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 12, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(387), "/images/Products/abe80eae-4676-4b5d-a30c-d701d9b29a46.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 11, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(399), "/images/Products/27404a72-183a-4749-b8d5-cea166f17bdc.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 10, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(427), "/images/Products/e654e742-0e3c-49c9-8ae7-54300aefc175.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 9, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(437), "/images/Products/9108cc6a-4b19-438f-b727-4077cb8643d6.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 8, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(455), "/images/Products/f3676bcb-d673-4367-8bf0-1dbe6bfca4e4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 7, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(465), "/images/Products/110f8519-7e53-43da-b846-8a93a6813532.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 6, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(475), "/images/Products/3f389250-c571-44a1-b9e4-f71f7af8807d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 5, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(484), "/images/Products/e49b424c-99bd-4ad6-a03e-5958ae34e5d8.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 4, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(518), "/images/Products/1ebcd53c-74f5-4a1d-9b07-d420ff9bd01e.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 3, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(528), "/images/Products/137b2256-8868-4736-9e71-60e4533e4d49.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 2, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(544), "/images/Products/1441dfea-f47b-4d28-84a0-f9ffa4864e56.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 9, 1, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(554), "/images/Products/b9daf6a6-faa7-45a5-80dd-755811e29043.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 8, 31, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(565), "/images/Products/9bc9f11a-b0d4-45ac-8a44-3823350ebda5.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CategoryId", "CreatedOn", "Image" },
                values: new object[] { null, new DateTime(2025, 8, 30, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(575), "/images/Products/13a2b9e3-9590-4c58-8c6c-087415658dac.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 7, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1633), "/images/Products/a464df14-3f5e-4173-9726-202c59be252c.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 6, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1671), "/images/Products/91ae23f8-eeb1-4f18-8683-392312654cca.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 5, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1681), "/images/Products/3fd9937b-4b99-4e0b-a275-413363408fb5.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 4, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1705), "/images/Products/98cb029b-8ea2-4165-a166-e156a981ff7e.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 3, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1714), "/images/Products/307fb41d-eca5-4873-a006-0abf769b7456.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 2, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1730), "/images/Products/d8ff8901-23a5-41af-8c96-17f4dab06ccd.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 1, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1738), "/images/Products/a0532a05-d894-4cd7-a54c-fb3dd5c0aece.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 31, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1747), "/images/Products/43c4d90a-550b-490c-9b98-68226cec31ce.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 30, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1755), "/images/Products/725cf7c6-3811-4d0d-a2af-d7bbd770a2fa.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 29, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1793), "/images/Products/6882a5d9-f9d6-483a-8c8e-d0b78c54e706.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 28, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1802), "/images/Products/6cb1bf01-c4bb-41f5-bc4b-f2a26feb543a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 27, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1815), "/images/Products/69aa8e35-15a0-4ac0-bf2d-60679a0e48de.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 26, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1823), "/images/Products/7fac8217-3d9f-4a37-9023-85e234ad7e0e.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 25, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1831), "/images/Products/9f7bc0c1-6d72-47ea-a4c1-59f5c3bbb546.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 24, 15, 19, 9, 247, DateTimeKind.Utc).AddTicks(1840), "/images/Products/eacf612c-b805-467f-8e21-0063cd71282b.png" });
        }
    }
}
