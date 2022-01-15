using Microsoft.EntityFrameworkCore.Migrations;

namespace ChainStoreSystem.Migrations
{
    public partial class AddSubCategoryToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sub_Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCategoryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Fid = table.Column<int>(type: "int", nullable: false),
                    CategorysId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Categorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sub_Categorie_categories_CategorysId",
                        column: x => x.CategorysId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Categorie_CategorysId",
                table: "Sub_Categorie",
                column: "CategorysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sub_Categorie");
        }
    }
}
