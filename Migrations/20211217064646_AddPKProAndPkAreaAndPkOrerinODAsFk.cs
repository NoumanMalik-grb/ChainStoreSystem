using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddPKProAndPkAreaAndPkOrerinODAsFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "orderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Area_Fid",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "orderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order_Fid",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "orderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Product_Fid",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_AreaId",
                table: "orderDetails",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrderId",
                table: "orderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_ProductId",
                table: "orderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_areas_AreaId",
                table: "orderDetails",
                column: "AreaId",
                principalTable: "areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_OrderId",
                table: "orderDetails",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_products_ProductId",
                table: "orderDetails",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_areas_AreaId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_OrderId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_products_ProductId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_AreaId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_OrderId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_ProductId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "Area_Fid",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "Order_Fid",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "orderDetails");

            migrationBuilder.DropColumn(
                name: "Product_Fid",
                table: "orderDetails");
        }
    }
}
