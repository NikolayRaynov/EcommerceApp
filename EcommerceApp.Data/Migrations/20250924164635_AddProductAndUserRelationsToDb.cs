using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndUserRelationsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FavoriteProductId",
                table: "Products",
                type: "int",
                nullable: true,
                comment: "Identifier of the favorite product",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FavoriteProductId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Identifier of the favorite product");

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
        }
    }
}
