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

            migrationBuilder.CreateTable(
                name: "Thz_Website",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thz_Website", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thz_DetailInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mosaic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image1Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TorrentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thz_DetailInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thz_DetailInfo_Thz_ListInfo_ListInfoId",
                        column: x => x.ListInfoId,
                        principalTable: "Thz_ListInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Thz_DetailInfo_ListInfoId",
                table: "Thz_DetailInfo",
                column: "ListInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thz_DetailInfo");

            migrationBuilder.DropTable(
                name: "Thz_Website");

            migrationBuilder.DropTable(
                name: "Thz_ListInfo");
        }
    }
}
