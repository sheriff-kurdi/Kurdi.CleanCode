using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kurdi.CleanCode.Infrastructure.Data.Migrations
{
    public partial class Cayegory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "stock_items",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    is_parent = table.Column<bool>(type: "boolean", nullable: false),
                    parent = table.Column<string>(type: "text", nullable: true),
                    parent1 = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_stock_items_category",
                table: "stock_items",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_categories_parent1",
                table: "categories",
                column: "parent1");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_items_categories_category",
                table: "stock_items",
                column: "category",
                principalTable: "categories",
                principalColumn: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_items_categories_category",
                table: "stock_items");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_stock_items_category",
                table: "stock_items");

            migrationBuilder.DropColumn(
                name: "category",
                table: "stock_items");
        }
    }
}
