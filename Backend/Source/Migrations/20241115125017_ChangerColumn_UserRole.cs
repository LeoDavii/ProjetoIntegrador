using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class ChangerColumn_UserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b48ff2e-9048-4525-a629-5cd9a7585b92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed9f2a25-f979-4126-b3a6-dc8c49094ba7"));

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "Users",
                newName: "Role");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("94fa33c7-d957-4cc5-b52f-18652fd318f8"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("96699c58-6007-4a85-9cbd-2c43cade3cb0"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94fa33c7-d957-4cc5-b52f-18652fd318f8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96699c58-6007-4a85-9cbd-2c43cade3cb0"));

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "UserType");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "UserType" },
                values: new object[,]
                {
                    { new Guid("1b48ff2e-9048-4525-a629-5cd9a7585b92"), null, "johnC@test.com.br", "John Customer", "test", 0 },
                    { new Guid("ed9f2a25-f979-4126-b3a6-dc8c49094ba7"), null, "johnM@test.com.br", "John Manager", "test", 1 }
                });
        }
    }
}
