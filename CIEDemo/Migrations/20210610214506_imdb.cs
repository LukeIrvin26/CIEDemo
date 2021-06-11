using Microsoft.EntityFrameworkCore.Migrations;

namespace CIEDemo.Migrations
{
    public partial class imdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IMDBLink",
                table: "movies",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMDBLink",
                table: "movies");
        }
    }
}
