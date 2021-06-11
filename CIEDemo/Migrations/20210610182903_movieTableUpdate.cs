using Microsoft.EntityFrameworkCore.Migrations;

namespace CIEDemo.Migrations
{
    public partial class movieTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "movies");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "movies",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearReleased",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearReleased",
                table: "movies");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "movies",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate",
                table: "movies",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
