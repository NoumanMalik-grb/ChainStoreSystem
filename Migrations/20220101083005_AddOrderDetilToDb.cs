using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddOrderDetilToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Purchase_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_FId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: true),
                    Area_FId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    Order_FId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderDetails_areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orderDetails_orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orderDetails_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_AreaId",
                table: "orderDetails",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrdersId",
                table: "orderDetails",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_ProductsId",
                table: "orderDetails",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");
        }
    }
}
