using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class UpdateComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FilmId",
                table: "Comments",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Films_FilmId",
                table: "Comments",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Films_FilmId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_FilmId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Comments");
        }
    }
}
