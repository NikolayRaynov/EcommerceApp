using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureVersionProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProfilePictureVersion",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 19, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8247), "/images/Products/5b36fb0d-8583-4738-b979-ad293a68dcdc.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 18, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8281), "/images/Products/b2198310-277a-40a5-bb9d-a0b8dbe986a0.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 17, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8293), "/images/Products/7ddb3171-fb56-44cf-b874-5af4242b447a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 16, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8426), "/images/Products/c014a701-18e8-4c4c-aa80-244fa0f016b3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 15, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8440), "/images/Products/96b52f1a-50c0-4361-9a4c-b20f497c8557.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 14, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8456), "/images/Products/2603f916-65d8-4015-a817-934b7bf496bc.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 13, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8487), "/images/Products/c02f90e3-ae51-430d-96ed-70318c4f89ce.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 12, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8499), "/images/Products/1ce1ee3a-f137-404b-85fa-a8d9997f34e9.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 11, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8510), "/images/Products/e85d492c-cb0d-43d3-8d4a-f13c6a8f6ea9.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 10, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8528), "/images/Products/22f6bb61-ba32-4ce7-bf0d-2cbbddca0871.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 9, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8539), "/images/Products/1c9d5e5c-ee9b-4139-82f3-1579919e3661.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 8, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8551), "/images/Products/bfa3efed-e3e1-439f-8a35-1cee6db25e4e.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 7, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8562), "/images/Products/0e27b698-890c-4759-bc65-2208a307b669.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8573), "/images/Products/cdd817ae-da4e-4526-ba52-8450d75cccea.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 5, 15, 15, 3, 779, DateTimeKind.Utc).AddTicks(8688), "/images/Products/c5e8770d-dc8d-4f2d-b6d6-7792b8950237.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureVersion",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 17, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2699), "/images/Products/54c5605a-2394-4a59-ad1b-4b61b9bd9240.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 16, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2743), "/images/Products/3ef237f9-e4d6-4ba1-81cd-98e85e24d84b.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 15, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2781), "/images/Products/27e7d606-4331-406d-9e85-7003b5c469df.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 14, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2795), "/images/Products/28dc8735-204e-4188-8342-1df1c766af47.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 13, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2809), "/images/Products/6841030b-5d3a-44a6-9e91-a7bce1caae08.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 12, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2829), "/images/Products/45376d6a-694a-45cf-add6-056d370ec712.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 11, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2843), "/images/Products/9a029cdd-3c79-4c9e-9ad5-34158903b0f3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 10, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2857), "/images/Products/5bc3e482-4201-4e18-9030-d8e6161de5a4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 9, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2877), "/images/Products/bfe708ae-fe1e-432e-900c-bc1d8216dfdd.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 8, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2898), "/images/Products/5b49e98c-2922-430c-b734-ba478c1f804f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 7, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2913), "/images/Products/4cfff90c-de33-4fd5-abaa-9e57d417baea.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 6, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2926), "/images/Products/90eebb49-07ea-45bc-af36-80831d749ee2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 5, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2952), "/images/Products/25ecd0d3-ce21-4784-800a-b931ffcce894.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 4, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2967), "/images/Products/f870c40c-58fa-4285-8753-c4ce74f4fca9.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 10, 3, 11, 46, 51, 460, DateTimeKind.Utc).AddTicks(2980), "/images/Products/e25e37a2-3c52-48c8-af32-9192da4cd81c.png" });
        }
    }
}
