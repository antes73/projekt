using Microsoft.EntityFrameworkCore.Migrations;

namespace bela.Migrations
{
    public partial class treca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "broj",
                table: "Partija");

            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Partija",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Partija");

            migrationBuilder.AddColumn<int>(
                name: "broj",
                table: "Partija",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
