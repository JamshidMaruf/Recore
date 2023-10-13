using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recore.Data.Migrations
{
    public partial class AddedDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_WareHouse_WareHouseId",
                table: "InventoryLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WareHouse",
                table: "WareHouse");

            migrationBuilder.RenameTable(
                name: "WareHouse",
                newName: "WareHouses");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsTop",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WareHouses",
                table: "WareHouses",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_WareHouses_WareHouseId",
                table: "InventoryLogs",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_WareHouses_WareHouseId",
                table: "InventoryLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WareHouses",
                table: "WareHouses");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsTop",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "WareHouses",
                newName: "WareHouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WareHouse",
                table: "WareHouse",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1511));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1513));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1515));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 19, 15, 32, 3, 997, DateTimeKind.Utc).AddTicks(1563));

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_WareHouse_WareHouseId",
                table: "InventoryLogs",
                column: "WareHouseId",
                principalTable: "WareHouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
