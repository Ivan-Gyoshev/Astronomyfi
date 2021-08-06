using Microsoft.EntityFrameworkCore.Migrations;

namespace Astronomyfi.Data.Migrations
{
    public partial class EditImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AuthorId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AuthorId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AuthorId",
                table: "Images",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AuthorId",
                table: "Images",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_AuthorId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AuthorId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Images",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AuthorId1",
                table: "Images",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_AuthorId1",
                table: "Images",
                column: "AuthorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
