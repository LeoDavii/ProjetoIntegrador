using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Source.Dtos;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class AdjustUserAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00c76994-269d-4e65-b3e2-50cdf32c3b53"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b1ba924-d5a2-4867-b8ac-d9b302362725"));

            migrationBuilder.AlterColumn<IEnumerable<AddressDto>>(
                name: "Adresses",
                table: "Users",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(IEnumerable<AddressDto>),
                oldType: "jsonb");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "UserType" },
                values: new object[,]
                {
                    { new Guid("1b48ff2e-9048-4525-a629-5cd9a7585b92"), null, "johnC@test.com.br", "John Customer", "test", 0 },
                    { new Guid("ed9f2a25-f979-4126-b3a6-dc8c49094ba7"), null, "johnM@test.com.br", "John Manager", "test", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b48ff2e-9048-4525-a629-5cd9a7585b92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed9f2a25-f979-4126-b3a6-dc8c49094ba7"));

            migrationBuilder.AlterColumn<IEnumerable<AddressDto>>(
                name: "Adresses",
                table: "Users",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(IEnumerable<AddressDto>),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "UserType" },
                values: new object[,]
                {
                    { new Guid("00c76994-269d-4e65-b3e2-50cdf32c3b53"), new AddressDto[0], "johnC@test.com.br", "John Customer", "test", 0 },
                    { new Guid("9b1ba924-d5a2-4867-b8ac-d9b302362725"), new AddressDto[0], "johnM@test.com.br", "John Manager", "test", 1 }
                });
        }
    }
}
