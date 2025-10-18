using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePictureProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 25, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(831), "/images/Products/a974b4f3-3929-44ca-bb6d-b9c3a91870cb.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 24, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(865), "/images/Products/b19bfbd0-793c-40fd-a5eb-f6612430b704.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 23, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1010), "/images/Products/5f88c123-7f4d-400d-a186-2cec6601bbe2.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 22, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1023), "/images/Products/8c05fbd4-887d-4ffb-bce0-35f087a19576.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 21, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1033), "/images/Products/1ebf3998-c63e-4faf-9b4d-4d8e09cf7736.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 20, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1049), "/images/Products/12ee9912-4de4-431d-a763-f4a38ec8a12f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 19, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1060), "/images/Products/026e8a71-9632-4c60-812a-fe32808f0fbd.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 18, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1069), "/images/Products/3261696c-d183-46b3-9e2f-224302843264.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 17, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1078), "/images/Products/2692e08d-98de-4809-bf25-dc746e7ec8fe.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 16, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1094), "/images/Products/c78d2829-5c22-4016-a9fb-8141eba3e4b3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 15, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1110), "/images/Products/ebad3203-9bcf-4107-8ae1-4d2556dd977e.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 14, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1120), "/images/Products/4f402d33-8859-4154-9b20-cebccf20b791.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1216), "/images/Products/fd3d9c0f-8f38-4464-b6a0-9d87485844b1.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1227), "/images/Products/e19fdecc-730a-4787-8bec-f852fd68c0ce.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 16, 9, 30, 934, DateTimeKind.Utc).AddTicks(1237), "/images/Products/576ef3fc-777f-457a-ac78-5f338f6d40b2.png" });
        }
    }
}
