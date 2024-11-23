using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Source.Migrations
{
    /// <inheritdoc />
    public partial class ChangerColumn_ImageDataToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7415890c-1fb0-4d66-9ae5-f3c406cbd685"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a8530d60-2082-49fd-9c61-3c5db863acc5"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("2dc312ba-150b-4cf3-8613-8fbac43de888"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("800e2081-8861-4876-a440-224315995f6c"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2dc312ba-150b-4cf3-8613-8fbac43de888"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("800e2081-8861-4876-a440-224315995f6c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adresses", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("7415890c-1fb0-4d66-9ae5-f3c406cbd685"), null, "johnM@test.com.br", "John Manager", "test", 1 },
                    { new Guid("a8530d60-2082-49fd-9c61-3c5db863acc5"), null, "johnC@test.com.br", "John Customer", "test", 0 }
                });
        }
    }
}
