using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeFlix.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleAnime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descriptionAnime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ratingAnime = table.Column<int>(type: "int", nullable: false),
                    imgAnime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trailerAnime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    runtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryAnime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime");
        }
    }
}
