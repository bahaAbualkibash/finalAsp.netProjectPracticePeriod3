using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class addJuntionTableLanguageFilmTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblLanguage_tblFilm",
                table: "tblLanguage");
            /*
            migrationBuilder.DropIndex(
                name: "IX_tblLanguage_FilmID",
                table: "tblLanguage");
            */
            migrationBuilder.DropColumn(
                name: "FilmID",
                table: "tblLanguage");
            /*
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "tblLanguage",
                type: "varchar(255)",
                unicode: false,
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);
            */
            migrationBuilder.CreateTable(
                name: "TblLanguagesMovies",
                columns: table => new
                {
                    LanguageFilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    LanguageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblLanguagesMovies", x => x.LanguageFilmID);
                    table.ForeignKey(
                        name: "FK_Tbl_Languages_Movies_tblFilm",
                        column: x => x.FilmID,
                        principalTable: "tblFilm",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Languages_Movies_tblLanguage",
                        column: x => x.LanguageID,
                        principalTable: "tblLanguage",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblLanguagesMovies_FilmID",
                table: "TblLanguagesMovies",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_TblLanguagesMovies_LanguageID",
                table: "TblLanguagesMovies",
                column: "LanguageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblLanguagesMovies");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "tblLanguage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldUnicode: false,
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmID",
                table: "tblLanguage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblLanguage_FilmID",
                table: "tblLanguage",
                column: "FilmID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblLanguage_tblFilm",
                table: "tblLanguage",
                column: "FilmID",
                principalTable: "tblFilm",
                principalColumn: "FilmID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
