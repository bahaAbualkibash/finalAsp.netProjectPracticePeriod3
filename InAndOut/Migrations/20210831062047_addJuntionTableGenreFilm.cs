using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class addJuntionTableGenreFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblGenre_tblFilm",
                table: "tblGenre");
            /*
            migrationBuilder.DropIndex(
                name: "IX_tblGenre_FilmId",
                table: "tblGenre");
            */
            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "tblGenre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "tblGenre",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblGenre_FilmId",
                table: "tblGenre",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblGenre_tblFilm",
                table: "tblGenre",
                column: "FilmId",
                principalTable: "tblFilm",
                principalColumn: "FilmID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
