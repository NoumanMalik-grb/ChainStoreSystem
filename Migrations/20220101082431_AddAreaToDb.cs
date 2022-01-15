using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddAreaToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Area_AreasId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Area",
                table: "Area");

            migrationBuilder.RenameTable(
                name: "Area",
                newName: "areas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_areas",
                table: "areas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_areas_AreasId",
                table: "products",
                column: "AreasId",
                principalTable: "areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_areas_AreasId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_areas",
                table: "areas");

            migrationBuilder.RenameTable(
                name: "areas",
                newName: "Area");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Area",
                table: "Area",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Area_AreasId",
                table: "products",
                column: "AreasId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
