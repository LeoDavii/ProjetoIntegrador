using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class ChangerColumn_ImageDataFileUri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94fa33c7-d957-4cc5-b52f-18652fd318f8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96699c58-6007-4a85-9cbd-2c43cade3cb0"));

            migrationBuilder.DropColumn(
                name: "FileUri",
                table: "Products");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Products",
                type: "bytea",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("7415890c-1fb0-4d66-9ae5-f3c406cbd685"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("a8530d60-2082-49fd-9c61-3c5db863acc5"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7415890c-1fb0-4d66-9ae5-f3c406cbd685"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a8530d60-2082-49fd-9c61-3c5db863acc5"));

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "FileUri",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("94fa33c7-d957-4cc5-b52f-18652fd318f8"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("96699c58-6007-4a85-9cbd-2c43cade3cb0"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }
    }
}
