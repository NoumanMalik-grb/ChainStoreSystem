using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddAreaPkTDamgdProductFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "damagedProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Area_Id",
                table: "damagedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_damagedProducts_AreaId",
                table: "damagedProducts",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_damagedProducts_areas_AreaId",
                table: "damagedProducts",
                column: "AreaId",
                principalTable: "areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_damagedProducts_areas_AreaId",
                table: "damagedProducts");

            migrationBuilder.DropIndex(
                name: "IX_damagedProducts_AreaId",
                table: "damagedProducts");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "damagedProducts");

            migrationBuilder.DropColumn(
                name: "Area_Id",
                table: "damagedProducts");
        }
    }
}
