using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddProductToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Discription_Max = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Discription_Min = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Product_Purchase_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Product_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Product_Add_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_Exp_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubCategory_Fid = table.Column<int>(type: "int", nullable: false),
                    SubCategorysId = table.Column<int>(type: "int", nullable: true),
                    Area_FId = table.Column<int>(type: "int", nullable: false),
                    AreasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_Area_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_Sub_Categorie_SubCategorysId",
                        column: x => x.SubCategorysId,
                        principalTable: "Sub_Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_AreasId",
                table: "products",
                column: "AreasId");

            migrationBuilder.CreateIndex(
                name: "IX_products_SubCategorysId",
                table: "products",
                column: "SubCategorysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
