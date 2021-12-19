using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddProductToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    SubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_Sub_Categorie_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "Sub_Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_SubCategoryId",
                table: "products",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
