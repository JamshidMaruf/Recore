using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recore.Data.Migrations
{
    public partial class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2561));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2563));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2565));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2565));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 25, 18, 803, DateTimeKind.Utc).AddTicks(2596));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 18, 13, 23, 19, 642, DateTimeKind.Utc).AddTicks(3950));
        }
    }
}
