using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Laptops" },
                    { 2, "Monitors" },
                    { 3, "Keyboards" },
                    { 7, "Games" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6846), "/images/Products/10527507-419c-4e4f-8131-a8b66a6d04f9.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6870), "/images/Products/d47efbe4-1506-484b-b8f7-1e0b86bcce91.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6955), "/images/Products/8dc2d3d2-c49f-4b72-af9d-b8d3e168d848.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6963), "/images/Products/0132eddb-7e96-4708-8e5f-c7edf780cb2d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6969), "/images/Products/1626c67f-ad55-4dba-9694-f10e0a45a688.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 8, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6978), "/images/Products/2c109b49-d195-4ba2-8e10-d9373c4f839b.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 7, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6983), "/images/Products/461cbf45-58eb-4c0e-aa3a-07c98490a550.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 6, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6989), "/images/Products/8afcddf3-b055-42e1-947a-8cc8d2df5c8a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 5, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(6994), "/images/Products/679983e5-b543-4eac-9ade-fc68bb411e50.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 4, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(7003), "/images/Products/53af54dc-0995-4ae0-9f0f-6f2f42f0e1c3.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 3, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(7013), "/images/Products/829937a5-b29c-486d-924a-b3545175d358.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 2, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(7018), "/images/Products/44d8c2b2-bbe0-4c6f-8dbc-f2775664534a.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 1, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(7024), "/images/Products/4de91be7-dab0-4020-88c4-ebc54634cf48.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 31, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(7029), "/images/Products/9358c8ce-f914-475e-9559-75848f8d67fd.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 30, 13, 8, 0, 724, DateTimeKind.Utc).AddTicks(7034), "/images/Products/6828792b-ae86-413d-bbe0-1d8dc7aa77a2.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 13, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(353), "/images/Products/6b431372-c649-469f-b35e-8b4bb6026a3f.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 12, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(387), "/images/Products/abe80eae-4676-4b5d-a30c-d701d9b29a46.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 11, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(399), "/images/Products/27404a72-183a-4749-b8d5-cea166f17bdc.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 10, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(427), "/images/Products/e654e742-0e3c-49c9-8ae7-54300aefc175.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 9, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(437), "/images/Products/9108cc6a-4b19-438f-b727-4077cb8643d6.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 8, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(455), "/images/Products/f3676bcb-d673-4367-8bf0-1dbe6bfca4e4.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 7, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(465), "/images/Products/110f8519-7e53-43da-b846-8a93a6813532.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 6, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(475), "/images/Products/3f389250-c571-44a1-b9e4-f71f7af8807d.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 5, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(484), "/images/Products/e49b424c-99bd-4ad6-a03e-5958ae34e5d8.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 4, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(518), "/images/Products/1ebcd53c-74f5-4a1d-9b07-d420ff9bd01e.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 3, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(528), "/images/Products/137b2256-8868-4736-9e71-60e4533e4d49.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 2, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(544), "/images/Products/1441dfea-f47b-4d28-84a0-f9ffa4864e56.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 9, 1, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(554), "/images/Products/b9daf6a6-faa7-45a5-80dd-755811e29043.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 31, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(565), "/images/Products/9bc9f11a-b0d4-45ac-8a44-3823350ebda5.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "Image" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 57, 44, 775, DateTimeKind.Utc).AddTicks(575), "/images/Products/13a2b9e3-9590-4c58-8c6c-087415658dac.png" });
        }
    }
}
