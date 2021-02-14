using Microsoft.EntityFrameworkCore.Migrations;

namespace bela.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZvanjaMi = table.Column<int>(nullable: false),
                    BodoviMi = table.Column<int>(nullable: false),
                    BodoviVi = table.Column<int>(nullable: false),
                    ZvanjaVi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bela", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bela");
        }
    }
}
