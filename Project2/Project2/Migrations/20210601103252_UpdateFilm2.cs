using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class UpdateFilm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Films");
        }
    }
}
