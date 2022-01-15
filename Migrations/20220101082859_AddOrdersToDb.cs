using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddOrdersToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Delivery_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Fid = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_ProductsId",
                table: "orders",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
