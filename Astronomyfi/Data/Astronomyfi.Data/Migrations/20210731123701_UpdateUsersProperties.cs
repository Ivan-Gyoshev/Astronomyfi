using Microsoft.EntityFrameworkCore.Migrations;

namespace Astronomyfi.Data.Migrations
{
    public partial class UpdateUsersProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountScore",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AvatarImgUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountScore",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AvatarImgUrl",
                table: "AspNetUsers");
        }
    }
}
