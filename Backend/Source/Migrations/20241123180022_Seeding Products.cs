using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b2edc87-1b54-442e-83fb-8b624b5a61e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5338c9f-37b4-446d-8f16-85f248ca81f4"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("237a869f-8682-4628-8102-e9aa552ed6be"), "Cupcake confeitado de baunilha", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20de%20baunilha.png", "Cupcake Baunilha", 12.550000000000001 },
                    { new Guid("5f7d7b1c-e111-4650-9305-b3b6efdc0078"), "Delicioso cupcake de chocolate 70%", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20de%20chocolate.jpeg", "Cupcake Chocolate", 14.550000000000001 },
                    { new Guid("ceef57b0-0a9c-4c4b-9d10-ea2674b0949f"), "Cupcake confeitado de Morango", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20morango.png", "Cupcake Morango", 15.550000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("176513ca-83e8-4703-8029-db473720375b"), null, "johnC@test.com.br", "John Customer", "test", 0 },
                    { new Guid("5b9759c5-f021-46dc-b8e6-3bed32998062"), null, "johnM@test.com.br", "John Manager", "test", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("237a869f-8682-4628-8102-e9aa552ed6be"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5f7d7b1c-e111-4650-9305-b3b6efdc0078"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceef57b0-0a9c-4c4b-9d10-ea2674b0949f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("176513ca-83e8-4703-8029-db473720375b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b9759c5-f021-46dc-b8e6-3bed32998062"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("3b2edc87-1b54-442e-83fb-8b624b5a61e1"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("d5338c9f-37b4-446d-8f16-85f248ca81f4"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }
    }
}
