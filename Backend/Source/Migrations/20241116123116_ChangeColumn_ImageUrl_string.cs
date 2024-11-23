using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumn_ImageUrl_string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("47888747-800c-4c56-857e-81b2a73d66dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8db8dc50-16cc-47ed-9b83-5ca536f01a6e"));

            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("3b2edc87-1b54-442e-83fb-8b624b5a61e1"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("d5338c9f-37b4-446d-8f16-85f248ca81f4"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b2edc87-1b54-442e-83fb-8b624b5a61e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5338c9f-37b4-446d-8f16-85f248ca81f4"));

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "ImageData");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("47888747-800c-4c56-857e-81b2a73d66dc"), null, "johnC@test.com.br", "John Customer", "test", 0 },
                    { new Guid("8db8dc50-16cc-47ed-9b83-5ca536f01a6e"), null, "johnM@test.com.br", "John Manager", "test", 1 }
                });
        }
    }
}
