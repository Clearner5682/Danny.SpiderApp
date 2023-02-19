using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Danny.SpiderApp.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image1Url",
                table: "Thz_DetailInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2Url",
                table: "Thz_DetailInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1Url",
                table: "Thz_DetailInfo");

            migrationBuilder.DropColumn(
                name: "Image2Url",
                table: "Thz_DetailInfo");
        }
    }
}
