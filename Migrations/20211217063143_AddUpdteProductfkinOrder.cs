using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddUpdteProductfkinOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_orders_OrderId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "orders",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_OrderId",
                table: "orders",
                newName: "IX_orders_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orders_ProductId",
                table: "orders",
                column: "ProductId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_orders_ProductId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ProductId",
                table: "orders",
                newName: "IX_orders_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orders_OrderId",
                table: "orders",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
