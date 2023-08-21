using Microsoft.EntityFrameworkCore.Migrations;

namespace product_app_test.Migrations
{
    public partial class update_ProductId_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryctg_id",
                table: "Product");

            migrationBuilder.DropPrimaryKey("PK_Product", "Product");

            migrationBuilder.DropIndex("IX_Product_categoryctg_id", "Product");

            migrationBuilder.RenameColumn("dbo.Product", "item_id", "I");

            migrationBuilder.AddColumn<int>(
                          name: "item_id",
                          table: "Product",
                          type: "int",
                          nullable: false
                          );


            migrationBuilder.AddPrimaryKey("PK_Product", "Product", "item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryctg_id",
                table: "Product",
                column: "categoryctg_id",
                principalTable: "Category",
                principalColumn: "ctg_id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade
        );
            migrationBuilder.CreateIndex(
               name: "IX_Product_categoryctg_id",
               table: "Product",
               column: "categoryctg_id");


            migrationBuilder.DropColumn("dbo.Product", "I");


           

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryctg_id",
                table: "Product");

            migrationBuilder.DropPrimaryKey("PK_Product", "Product");

            migrationBuilder.DropIndex("IX_Product_categoryctg_id", "Product");

            migrationBuilder.RenameColumn("Product", "item_id", "I");

            migrationBuilder.AddColumn<int>(
                          name: "item_id",
                          table: "Product",
                          type: "tinyint",
                          nullable: false
                          );


            migrationBuilder.AddPrimaryKey("PK_Product", "dbo.Product", "item_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryctg_id",
                table: "Product",
                column: "categoryctg_id",
                principalTable: "Category",
                principalColumn: "ctg_id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade
        );
            migrationBuilder.CreateIndex(
               name: "IX_Product_categoryctg_id",
               table: "Product",
               column: "categoryctg_id");


            migrationBuilder.DropColumn("dbo.Product", "I");


        }
    }
}
