using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class ChangerColumn_ImageData_string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2dc312ba-150b-4cf3-8613-8fbac43de888"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("800e2081-8861-4876-a440-224315995f6c"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageData",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("47888747-800c-4c56-857e-81b2a73d66dc"), null, "johnC@test.com.br", "John Customer", "test", 0 },
                    { new Guid("8db8dc50-16cc-47ed-9b83-5ca536f01a6e"), null, "johnM@test.com.br", "John Manager", "test", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("47888747-800c-4c56-857e-81b2a73d66dc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8db8dc50-16cc-47ed-9b83-5ca536f01a6e"));

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageData",
                table: "Products",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("2dc312ba-150b-4cf3-8613-8fbac43de888"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("800e2081-8861-4876-a440-224315995f6c"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }
    }
}
