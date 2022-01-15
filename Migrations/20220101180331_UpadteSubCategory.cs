using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class UpadteSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Categorie_categories_CategorysId",
                table: "Sub_Categorie");

            migrationBuilder.RenameColumn(
                name: "CategorysId",
                table: "Sub_Categorie",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Sub_Categorie_CategorysId",
                table: "Sub_Categorie",
                newName: "IX_Sub_Categorie_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Categorie_categories_CategoryId",
                table: "Sub_Categorie",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sub_Categorie_categories_CategoryId",
                table: "Sub_Categorie");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Sub_Categorie",
                newName: "CategorysId");

            migrationBuilder.RenameIndex(
                name: "IX_Sub_Categorie_CategoryId",
                table: "Sub_Categorie",
                newName: "IX_Sub_Categorie_CategorysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sub_Categorie_categories_CategorysId",
                table: "Sub_Categorie",
                column: "CategorysId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
