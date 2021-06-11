using Microsoft.EntityFrameworkCore.Migrations;

namespace CIEDemo.Migrations
{
    public partial class movieUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "movies",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "movies",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Runtime",
                table: "movies",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "Runtime",
                table: "movies");
        }
    }
}
