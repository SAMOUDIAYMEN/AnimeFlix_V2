using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeFlix.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "categoryAnime",
                table: "Anime",
                newName: "categoryid");

            migrationBuilder.CreateTable(
                name: "CategoryAnime",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAnime", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_categoryid",
                table: "Anime",
                column: "categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_CategoryAnime_categoryid",
                table: "Anime",
                column: "categoryid",
                principalTable: "CategoryAnime",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_CategoryAnime_categoryid",
                table: "Anime");

            migrationBuilder.DropTable(
                name: "CategoryAnime");

            migrationBuilder.DropIndex(
                name: "IX_Anime_categoryid",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "Anime",
                newName: "categoryAnime");
        }
    }
}
