using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Danny.SpiderApp.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thz_ListInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentNum = table.Column<int>(type: "int", nullable: true),
                    ViewNum = table.Column<int>(type: "int", nullable: true),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ViewUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thz_ListInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thz_ListInfo");
        }
    }
}
