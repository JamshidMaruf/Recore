using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recore.Data.Migrations
{
    public partial class Addedchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Inventories",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Inventories",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 17, 43, 10, 245, DateTimeKind.Utc).AddTicks(5371));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Inventories",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

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
    }
}
