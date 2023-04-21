using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneMarket.AccessLayer.Migrations
{
    public partial class update44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Stores_StoreId",
                table: "Brand");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGallery_Products_ProductId",
                table: "ProductGallery");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategories_Categories_CategoryId",
                table: "StoreCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategories_Stores_UserId",
                table: "StoreCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Atterbuit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategories",
                table: "StoreCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGallery",
                table: "ProductGallery");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Store");

            migrationBuilder.RenameTable(
                name: "StoreCategories",
                newName: "StoreCategory");

            migrationBuilder.RenameTable(
                name: "ProductGallery",
                newName: "ProductGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategories_UserId",
                table: "StoreCategory",
                newName: "IX_StoreCategory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategories_CategoryId",
                table: "StoreCategory",
                newName: "IX_StoreCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGallery_ProductId",
                table: "ProductGalleries",
                newName: "IX_ProductGalleries_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductGalleries",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "ProductGalleries",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategory",
                table: "StoreCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGalleries",
                table: "ProductGalleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Store_StoreId",
                table: "Brand",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGalleries_Products_ProductId",
                table: "ProductGalleries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Users_UserId",
                table: "Store",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategory_Categories_CategoryId",
                table: "StoreCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategory_Store_UserId",
                table: "StoreCategory",
                column: "UserId",
                principalTable: "Store",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Store_StoreId",
                table: "Brand");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGalleries_Products_ProductId",
                table: "ProductGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Users_UserId",
                table: "Store");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategory_Categories_CategoryId",
                table: "StoreCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategory_Store_UserId",
                table: "StoreCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategory",
                table: "StoreCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGalleries",
                table: "ProductGalleries");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "ProductGalleries");

            migrationBuilder.RenameTable(
                name: "StoreCategory",
                newName: "StoreCategories");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "ProductGalleries",
                newName: "ProductGallery");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategory_UserId",
                table: "StoreCategories",
                newName: "IX_StoreCategories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategory_CategoryId",
                table: "StoreCategories",
                newName: "IX_StoreCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGalleries_ProductId",
                table: "ProductGallery",
                newName: "IX_ProductGallery_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ProductGallery",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategories",
                table: "StoreCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGallery",
                table: "ProductGallery",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Atterbuit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atterbuit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atterbuit_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atterbuit_ProductId",
                table: "Atterbuit",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Stores_StoreId",
                table: "Brand",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGallery_Products_ProductId",
                table: "ProductGallery",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategories_Categories_CategoryId",
                table: "StoreCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategories_Stores_UserId",
                table: "StoreCategories",
                column: "UserId",
                principalTable: "Stores",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Users_UserId",
                table: "Stores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
