using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Recore.Data.Migrations
{
    public partial class AttachmentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.AddColumn<long>(
                name: "AttachmentId",
                table: "Vehicles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AttachmentId",
                table: "Suppliers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "AttachmentId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FIlePath = table.Column<string>(type: "text", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 23, 18, 23, 40, 327, DateTimeKind.Utc).AddTicks(1846));

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_AttachmentId",
                table: "Vehicles",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AttachmentId",
                table: "Suppliers",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AttachmentId",
                table: "Products",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Attachments_AttachmentId",
                table: "Products",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Attachments_AttachmentId",
                table: "Suppliers",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Attachments_AttachmentId",
                table: "Vehicles",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Attachments_AttachmentId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Attachments_AttachmentId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Attachments_AttachmentId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_AttachmentId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_AttachmentId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Products_AttachmentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9462));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsDeleted", "Name", "Price", "Quantity", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9657), "", false, "Cheeseburger", 24000m, 10.0, 4, null },
                    { 2L, 8L, new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9692), "", false, "Coffee", 7000m, 10.0, 4, null },
                    { 3L, 9L, new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9694), "", false, "Moxito", 15000m, 10.0, 4, null },
                    { 4L, 10L, new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9696), "", false, "Ketchup", 3000m, 10.0, 4, null },
                    { 5L, 5L, new DateTime(2023, 8, 22, 19, 17, 50, 615, DateTimeKind.Utc).AddTicks(9697), "", false, "Caesar", 23000m, 10.0, 4, null }
                });
        }
    }
}
