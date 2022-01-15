using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddDamageProdcToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "damagedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Area_FId = table.Column<int>(type: "int", nullable: false),
                    AreasId = table.Column<int>(type: "int", nullable: true),
                    Product_Fid = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_damagedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_damagedProducts_areas_AreasId",
                        column: x => x.AreasId,
                        principalTable: "areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_damagedProducts_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_damagedProducts_AreasId",
                table: "damagedProducts",
                column: "AreasId");

            migrationBuilder.CreateIndex(
                name: "IX_damagedProducts_ProductsId",
                table: "damagedProducts",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "damagedProducts");
        }
    }
}
