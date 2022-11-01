using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kurdi.CleanCode.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Salary = table.Column<double>(type: "double precision", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    language_code = table.Column<string>(type: "text", nullable: false),
                    language_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.language_code);
                });

            migrationBuilder.CreateTable(
                name: "stock_items",
                columns: table => new
                {
                    sku = table.Column<string>(type: "text", nullable: false),
                    supplier_identity = table.Column<int>(type: "integer", nullable: false),
                    selling_price = table.Column<double>(type: "double precision", nullable: true),
                    cost_price = table.Column<double>(type: "double precision", nullable: true),
                    discount = table.Column<double>(type: "double precision", nullable: true),
                    is_discounted = table.Column<bool>(type: "boolean", nullable: true),
                    total_stock = table.Column<int>(type: "integer", nullable: true),
                    available_stock = table.Column<int>(type: "integer", nullable: true),
                    reserved_stock = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_items", x => x.sku);
                });

            migrationBuilder.CreateTable(
                name: "stock_items_details",
                columns: table => new
                {
                    language_code = table.Column<string>(type: "text", nullable: false),
                    sku = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
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
        }
    }
}
