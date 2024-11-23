using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Source.Dtos;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class RemovingOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

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
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("62c050e4-9848-4834-b0ee-839f70c3c9ae"), "Cupcake confeitado de Morango", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20morango.png", "Cupcake Morango", 15.550000000000001 },
                    { new Guid("90a59928-f879-4ba3-9ae6-d3ff7d0e133e"), "Cupcake confeitado de baunilha", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20de%20baunilha.png", "Cupcake Baunilha", 12.550000000000001 },
                    { new Guid("f1cb1024-08d4-4985-95c9-9a78753ef199"), "Delicioso cupcake de chocolate 70%", "https://raw.githubusercontent.com/LeoDavii/sources/refs/heads/main/cupcake%20de%20chocolate.jpeg", "Cupcake Chocolate", 14.550000000000001 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("63129334-0a4f-4fe5-9c6c-e65ee4e0f30f"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("6de158f5-a9a0-431b-8b8a-c00455a06771"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62c050e4-9848-4834-b0ee-839f70c3c9ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90a59928-f879-4ba3-9ae6-d3ff7d0e133e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1cb1024-08d4-4985-95c9-9a78753ef199"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("63129334-0a4f-4fe5-9c6c-e65ee4e0f30f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6de158f5-a9a0-431b-8b8a-c00455a06771"));

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<AddressDto>(type: "jsonb", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Products = table.Column<IEnumerable<ProductDto>>(type: "jsonb", nullable: false),
                    TotalValue = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

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
    }
}
