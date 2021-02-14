using Microsoft.EntityFrameworkCore.Migrations;

namespace bela.Migrations
{
    public partial class druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartijaId",
                table: "Bela",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Partija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    broj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partija", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bela_PartijaId",
                table: "Bela",
                column: "PartijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bela_Partija_PartijaId",
                table: "Bela",
                column: "PartijaId",
                principalTable: "Partija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bela_Partija_PartijaId",
                table: "Bela");

            migrationBuilder.DropTable(
                name: "Partija");

            migrationBuilder.DropIndex(
                name: "IX_Bela_PartijaId",
                table: "Bela");

            migrationBuilder.DropColumn(
                name: "PartijaId",
                table: "Bela");
        }
    }
}
