using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddTableToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "companyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyDetails", x => x.Id);
                });

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
                    Order_Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Fid = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Categorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sub_Categorie_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_products_areas_AreasId",
                        column: x => x.AreasId,
                        principalTable: "areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_products_Sub_Categorie_SubCategorysId",
                        column: x => x.SubCategorysId,
                        principalTable: "Sub_Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sale_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Purchase_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_damagedProducts_AreasId",
                table: "damagedProducts",
                column: "AreasId");

            migrationBuilder.CreateIndex(
                name: "IX_damagedProducts_ProductsId",
                table: "damagedProducts",
                column: "ProductsId");

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

            migrationBuilder.CreateIndex(
                name: "IX_products_AreasId",
                table: "products",
                column: "AreasId");

            migrationBuilder.CreateIndex(
                name: "IX_products_SubCategorysId",
                table: "products",
                column: "SubCategorysId");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categorie_CategoryId",
                table: "Sub_Categorie",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "companyDetails");

            migrationBuilder.DropTable(
                name: "damagedProducts");

            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "Sub_Categorie");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
