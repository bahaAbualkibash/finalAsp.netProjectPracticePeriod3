using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class addJuntionTableGenreFilmTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblGenreMovies",
                columns: table => new
                {
                    ActorFilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGenreMovies", x => x.ActorFilmID);
                    table.ForeignKey(
                        name: "FK_Tbl_Genres_Movies_tblFilm",
                        column: x => x.FilmID,
                        principalTable: "tblFilm",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Genres_Movies_tblGenre",
                        column: x => x.GenreID,
                        principalTable: "tblGenre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblGenreMovies_FilmID",
                table: "TblGenreMovies",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_TblGenreMovies_GenreID",
                table: "TblGenreMovies",
                column: "GenreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblGenreMovies");
        }
    }
}
