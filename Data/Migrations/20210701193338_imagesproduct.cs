using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class imagesproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImageMappings");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImageMappings",
                newName: "IX_ProductImageMappings_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ImageId",
                table: "ProductImageMappings",
                newName: "IX_ProductImageMappings_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImageMappings",
                table: "ProductImageMappings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageMappings_Images_ImageId",
                table: "ProductImageMappings",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImageMappings_Products_ProductId",
                table: "ProductImageMappings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageMappings_Images_ImageId",
                table: "ProductImageMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImageMappings_Products_ProductId",
                table: "ProductImageMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImageMappings",
                table: "ProductImageMappings");

            migrationBuilder.RenameTable(
                name: "ProductImageMappings",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImageMappings_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImageMappings_ImageId",
                table: "ProductImages",
                newName: "IX_ProductImages_ImageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Images_ImageId",
                table: "ProductImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
