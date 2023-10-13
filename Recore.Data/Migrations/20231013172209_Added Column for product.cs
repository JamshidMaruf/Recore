using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recore.Data.Migrations
{
    public partial class AddedColumnforproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(71));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 22, 9, 247, DateTimeKind.Utc).AddTicks(79));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 8, 29, 522, DateTimeKind.Utc).AddTicks(4521));
        }
    }
}
