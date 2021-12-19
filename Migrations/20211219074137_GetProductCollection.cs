using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class GetProductCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Sub_Categorie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categorie_ProductId",
                table: "Sub_Categorie",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Categorie_products_ProductId",
                table: "Sub_Categorie",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Categorie_products_ProductId",
                table: "Sub_Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Sub_Categorie_ProductId",
                table: "Sub_Categorie");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Sub_Categorie");
        }
    }
}
