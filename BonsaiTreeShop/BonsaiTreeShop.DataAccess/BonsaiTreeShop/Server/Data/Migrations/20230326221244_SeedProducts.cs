using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BonsaiTreeShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21237790-9d1c-4b7c-a724-7b2201013611");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7a3f6cf-93d8-4a88-8474-91feae4e9f1e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ff3d3ba-9973-45a8-8002-3f7282359327", null, "Admin", "ADMIN" },
                    { "b1bae87c-ddd8-4578-9f54-647112c45864", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Image", "IsInStock", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("4d31c5e1-bdfa-4655-9292-ce53642a5e14"), "Azalea", "The Azalea is popular and well-known for its spectacular flowers, which open in late Spring and come in many different colors, shapes, sizes and patterns. In Japan special Azalea Bonsai festivals are organized around the time the trees flower.", "https://www.bonsaiempire.com/images/carrousel/Azalea04-bonsai.jpg", true, "Azalea With Exposed Roots", 4999m },
                    { new Guid("b6891a6d-a557-4849-9784-1a032d4ce8c3"), "Olive", "Olive trees are well ramified evergreen trees or shrubs and, depending on the variety, can become up to 10 or even 20 meters (33 to 66 ft) tall. Wild olive trees, called oleaster, are smaller than cultivars.", "https://www.bonsaiempire.com/images/carrousel/Olive04-bonsai.jpg", true, "Olive Bonsai Cascade", 2999m },
                    { new Guid("d6d34746-b400-4f18-8ba5-80b5ba2d7b09"), "Juniper", "The Juniper Bonsai trees that can be found in large stores, like Walmart and Home Depot, are often Japanese Garden Junipers, also known as Green Mound Junipers (Juniperus procumbens nana).", "https://www.bonsaiempire.com/images/carrousel/Juniper01.jpg", true, "Juniper Bonsai", 3199m },
                    { new Guid("de779ead-92e0-4db5-9f67-5fa653a4bd64"), "Azalea", "The Azalea is popular and well-known for its spectacular flowers, which open in late Spring and come in many different colors, shapes, sizes and patterns. In Japan special Azalea Bonsai festivals are organized around the time the trees flower.", "https://www.bonsaiempire.com/images/carrousel/Azalea01-Satsuki-azalea.jpg", true, "Azalea Bonsai", 2999m },
                    { new Guid("dfd34851-dbb0-4318-a6a5-8021e39399bf"), "Ficus", "Depending on where you look, there is different information as to the exact number of existing Ficus tree species. We know that there may be between 800 and 2000 different species.", "https://www.bonsaiempire.com/images/carrousel/ficus04-retusa-large.jpg", true, "Ficus Bonsai", 1999m },
                    { new Guid("e85e66cb-d1fb-4b46-be32-eec05575b8fd"), "Maple", "A beautiful Japanese Maple Bonsai Tree", "https://www.bonsaitreegardener.net/wp-content/uploads/2015/04/japanese-maple-bonsai-tree.jpg", true, "Japanese Maple Bonsai Tree", 211m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ff3d3ba-9973-45a8-8002-3f7282359327");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1bae87c-ddd8-4578-9f54-647112c45864");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d31c5e1-bdfa-4655-9292-ce53642a5e14"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6891a6d-a557-4849-9784-1a032d4ce8c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d6d34746-b400-4f18-8ba5-80b5ba2d7b09"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("de779ead-92e0-4db5-9f67-5fa653a4bd64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dfd34851-dbb0-4318-a6a5-8021e39399bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e85e66cb-d1fb-4b46-be32-eec05575b8fd"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21237790-9d1c-4b7c-a724-7b2201013611", null, "Customer", "CUSTOMER" },
                    { "f7a3f6cf-93d8-4a88-8474-91feae4e9f1e", null, "Admin", "ADMIN" }
                });
        }
    }
}
