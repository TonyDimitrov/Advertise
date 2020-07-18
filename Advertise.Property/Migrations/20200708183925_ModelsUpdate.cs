using Microsoft.EntityFrameworkCore.Migrations;

namespace Advertise.Property.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Advertises");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Advertises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Properties_PropertyId",
                table: "Images",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
