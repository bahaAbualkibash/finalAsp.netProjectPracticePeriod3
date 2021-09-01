using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class addKeyToActorMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorFilmID",
                table: "Tbl_Actors_Movies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Actors_Movies",
                table: "Tbl_Actors_Movies",
                column: "ActorFilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Actors_Movies",
                table: "Tbl_Actors_Movies");

            migrationBuilder.DropColumn(
                name: "ActorFilmID",
                table: "Tbl_Actors_Movies");
        }
    }
}
