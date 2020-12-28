using Microsoft.EntityFrameworkCore.Migrations;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    public partial class atualizando5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Projetos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Projetos");
        }
    }
}
