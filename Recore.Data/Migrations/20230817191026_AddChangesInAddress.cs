using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recore.Data.Migrations
{
    public partial class AddChangesInAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Regions_RegionId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Cities_CityId",
                table: "Regions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Regions",
                newName: "NameUz");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Regions",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_CityId",
                table: "Regions",
                newName: "IX_Regions_RegionId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "NameUz");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Addresses",
                newName: "DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                newName: "IX_Addresses_DistrictId");

            migrationBuilder.AddColumn<string>(
                name: "NameOz",
                table: "Regions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRu",
                table: "Regions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOz",
                table: "Cities",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameRu",
                table: "Cities",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1140));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1143));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1146));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1270));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 17, 19, 10, 26, 612, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_RegionId",
                table: "Addresses",
                column: "RegionId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Regions_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Cities_RegionId",
                table: "Regions",
                column: "RegionId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_RegionId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Regions_DistrictId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Cities_RegionId",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "NameOz",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "NameRu",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "NameOz",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "NameRu",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Regions",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "NameUz",
                table: "Regions",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_RegionId",
                table: "Regions",
                newName: "IX_Regions_CityId");

            migrationBuilder.RenameColumn(
                name: "NameUz",
                table: "Cities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DistrictId",
                table: "Addresses",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_DistrictId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1362));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1364));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 4, 19, 20, 2, 968, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Regions_RegionId",
                table: "Addresses",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Cities_CityId",
                table: "Regions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
