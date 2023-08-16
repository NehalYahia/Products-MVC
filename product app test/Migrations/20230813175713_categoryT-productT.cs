using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace product_app_test.Migrations
{
    public partial class categoryTproductT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ctg_id = table.Column<byte>(type: "tinyint", nullable: false),
                    ctg_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ctg_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    item_id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    item_img = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    item_dec = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    ctg_id = table.Column<byte>(type: "tinyint", nullable: false),
                    categoryctg_id = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.item_id);
                    table.ForeignKey(
                        name: "FK_Product_Category_categoryctg_id",
                        column: x => x.categoryctg_id,
                        principalTable: "Category",
                        principalColumn: "ctg_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryctg_id",
                table: "Product",
                column: "categoryctg_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
