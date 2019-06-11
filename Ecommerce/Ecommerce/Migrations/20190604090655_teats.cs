using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class teats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_categoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Category",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "imageurl",
                table: "Product",
                type: "VARCHAR (MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Product",
                type: "VARCHAR (500)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Category",
                type: "VARCHAR (500)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "categoryname",
                table: "Category",
                type: "VARCHAR (50)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_categoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "categoryId");

            migrationBuilder.AlterColumn<string>(
                name: "imageurl",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR (MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Product",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR (500)");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Category",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR (500)");

            migrationBuilder.AlterColumn<string>(
                name: "categoryname",
                table: "Category",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR (50)");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryId",
                table: "Product",
                column: "categoryId",
                principalTable: "Category",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
