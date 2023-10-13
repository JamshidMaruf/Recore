using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recore.Data.Migrations
{
    public partial class Addedchange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_WareHouses_WareHouseId",
                table: "InventoryLogs");

            migrationBuilder.RenameColumn(
                name: "WareHouseId",
                table: "InventoryLogs",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogs_WareHouseId",
                table: "InventoryLogs",
                newName: "IX_InventoryLogs_WarehouseId");

            migrationBuilder.AddColumn<long>(
                name: "WarehouseId",
                table: "Inventories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(136));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(139));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(140));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(143));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 10, 13, 18, 37, 48, 989, DateTimeKind.Utc).AddTicks(144));

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId",
                table: "Inventories",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_WareHouses_WarehouseId",
                table: "Inventories",
                column: "WarehouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_WareHouses_WarehouseId",
                table: "InventoryLogs",
                column: "WarehouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_WareHouses_WarehouseId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_WareHouses_WarehouseId",
                table: "InventoryLogs");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_WarehouseId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "InventoryLogs",
                newName: "WareHouseId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogs_WarehouseId",
                table: "InventoryLogs",
                newName: "IX_InventoryLogs_WareHouseId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_WareHouses_WareHouseId",
                table: "InventoryLogs",
                column: "WareHouseId",
                principalTable: "WareHouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
