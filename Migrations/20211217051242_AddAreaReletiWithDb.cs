using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddAreaReletiWithDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Area_Id",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AreasId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_AreasId",
                table: "products",
                column: "AreasId");

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

            migrationBuilder.DropIndex(
                name: "IX_products_AreasId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Area_Id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "AreasId",
                table: "products");
        }
    }
}
