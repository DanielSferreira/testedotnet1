using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    public partial class Atualizando_estrutura_das_tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BancoHoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataId = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(name: "Data Inicio", nullable: false),
                    DataFinal = table.Column<DateTime>(name: "Data Final", nullable: false),
                    desenvolvedor = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoHoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desenvolvedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nomedesenvolvedor = table.Column<string>(name: "Nome desenvolvedor", maxLength: 120, nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    Valorporhora = table.Column<double>(name: "Valor por hora", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancoHoras");

            migrationBuilder.DropTable(
                name: "Desenvolvedor");
        }
    }
}
