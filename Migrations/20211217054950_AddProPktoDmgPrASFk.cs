using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddProPktoDmgPrASFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "damagedProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_Fid",
                table: "damagedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_damagedProducts_ProductId",
                table: "damagedProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_damagedProducts_products_ProductId",
                table: "damagedProducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_damagedProducts_products_ProductId",
                table: "damagedProducts");

            migrationBuilder.DropIndex(
                name: "IX_damagedProducts_ProductId",
                table: "damagedProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "damagedProducts");

            migrationBuilder.DropColumn(
                name: "Product_Fid",
                table: "damagedProducts");
        }
    }
}
