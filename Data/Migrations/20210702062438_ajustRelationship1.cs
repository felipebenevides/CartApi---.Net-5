using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ajustRelationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_Products_ImagesId1",
                table: "ImageProduct");

            migrationBuilder.RenameColumn(
                name: "ImagesId1",
                table: "ImageProduct",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProduct_ImagesId1",
                table: "ImageProduct",
                newName: "IX_ImageProduct_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_Products_ProductsId",
                table: "ImageProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_Products_ProductsId",
                table: "ImageProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ImageProduct",
                newName: "ImagesId1");

            migrationBuilder.RenameIndex(
                name: "IX_ImageProduct_ProductsId",
                table: "ImageProduct",
                newName: "IX_ImageProduct_ImagesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_Products_ImagesId1",
                table: "ImageProduct",
                column: "ImagesId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
