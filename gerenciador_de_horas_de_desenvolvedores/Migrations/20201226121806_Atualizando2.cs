using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    public partial class Atualizando2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "desenvolvedor",
                table: "BancoHoras",
                newName: "Desenvolvedor");

            migrationBuilder.CreateTable(
                name: "HorasAcomuladasDev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Desenvolvedor = table.Column<string>(nullable: true),
                    HorasAcomuladas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasAcomuladasDev", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorasAcomuladasDev");

            migrationBuilder.RenameColumn(
                name: "Desenvolvedor",
                table: "BancoHoras",
                newName: "desenvolvedor");
        }
    }
}
