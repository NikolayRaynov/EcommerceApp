using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageRelationToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
