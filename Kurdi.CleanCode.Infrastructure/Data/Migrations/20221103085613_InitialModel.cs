using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kurdi.CleanCode.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    is_parent = table.Column<bool>(type: "bit", nullable: false),
                    parent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.name);
                    table.ForeignKey(
                        name: "FK_categories_categories_parent1",
                        column: x => x.parent1,
                        principalTable: "categories",
                        principalColumn: "name");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    language_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    language_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.language_code);
                });

            migrationBuilder.CreateTable(
                name: "stock_items",
                columns: table => new
                {
                    sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    supplier_identity = table.Column<int>(type: "int", nullable: false),
                    selling_price = table.Column<double>(type: "float", nullable: true),
                    cost_price = table.Column<double>(type: "float", nullable: true),
                    discount = table.Column<double>(type: "float", nullable: true),
                    is_discounted = table.Column<bool>(type: "bit", nullable: true),
                    total_stock = table.Column<int>(type: "int", nullable: true),
                    available_stock = table.Column<int>(type: "int", nullable: true),
                    reserved_stock = table.Column<int>(type: "int", nullable: true),
                    category = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_items", x => x.sku);
                    table.ForeignKey(
                        name: "FK_stock_items_categories_category",
                        column: x => x.category,
                        principalTable: "categories",
                        principalColumn: "name");
                });

            migrationBuilder.CreateTable(
                name: "stock_items_details",
                columns: table => new
                {
                    language_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_items_details", x => new { x.language_code, x.sku });
                    table.ForeignKey(
                        name: "FK_stock_items_details_languages_language_code",
                        column: x => x.language_code,
                        principalTable: "languages",
                        principalColumn: "language_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stock_items_details_stock_items_sku",
                        column: x => x.sku,
                        principalTable: "stock_items",
                        principalColumn: "sku",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent1",
                table: "categories",
                column: "parent1");

            migrationBuilder.CreateIndex(
                name: "IX_stock_items_category",
                table: "stock_items",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_stock_items_details_sku",
                table: "stock_items_details",
                column: "sku");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "stock_items_details");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "stock_items");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
