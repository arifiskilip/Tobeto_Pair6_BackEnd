using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6254), null, "Telefon", null },
                    { 2, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6257), null, "Bilgisayar", null },
                    { 3, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6259), null, "Manav", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "DeletedDate", "Name", "Stock", "UnitPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6528), null, "Telefon 1", 200, 100m, null },
                    { 2, 1, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6530), null, "Telefon 2", 80, 40m, null },
                    { 3, 2, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6532), null, "Bilgisayar 1", 1000, 100m, null },
                    { 4, 2, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6534), null, "Bilgisayar 2", 1500, 70m, null },
                    { 5, 2, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6536), null, "Bilgisayar 3", 35, 2200m, null },
                    { 6, 3, new DateTime(2024, 4, 1, 22, 53, 24, 677, DateTimeKind.Local).AddTicks(6538), null, "Manav 1", 1000, 10m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
