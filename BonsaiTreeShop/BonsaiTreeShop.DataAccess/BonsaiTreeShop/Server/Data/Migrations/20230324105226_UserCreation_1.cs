using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BonsaiTreeShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserCreation_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cc786d2-5e77-4777-a43b-969ded2f1102");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b416e975-1ff1-493c-bdea-6185eeb8af14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1667a722-3dc8-4262-bfb1-3111c10dae0e", null, "Admin", "ADMIN" },
                    { "f36ead4d-7fd4-428b-b8de-f2b13a375e88", null, "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1667a722-3dc8-4262-bfb1-3111c10dae0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f36ead4d-7fd4-428b-b8de-f2b13a375e88");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8cc786d2-5e77-4777-a43b-969ded2f1102", null, "Customer", "CUSTOMER" },
                    { "b416e975-1ff1-493c-bdea-6185eeb8af14", null, "Admin", "ADMIN" }
                });
        }
    }
}
