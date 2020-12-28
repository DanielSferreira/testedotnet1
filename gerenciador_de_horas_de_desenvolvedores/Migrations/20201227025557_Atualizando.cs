using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    public partial class Atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BancoHoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(name: "Data Inicio", nullable: false),
                    DataFinal = table.Column<DateTime>(name: "Data Final", nullable: false),
                    Desenvolvedor = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoHoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    DesenvolvedorTableId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 120, nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    Valorporhora = table.Column<double>(name: "Valor por hora", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.DesenvolvedorTableId);
                });

            migrationBuilder.CreateTable(
                name: "HorasAcomuladasDev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Desenvolvedor = table.Column<string>(nullable: true),
                    HorasAcomuladas = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasAcomuladasDev", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    projeto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevsEmProjetosTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Desenvolvedor = table.Column<string>(nullable: true),
                    ProjetoTableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevsEmProjetosTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevsEmProjetosTable_Projetos_ProjetoTableId",
                        column: x => x.ProjetoTableId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevsEmProjetosTable_ProjetoTableId",
                table: "DevsEmProjetosTable",
                column: "ProjetoTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancoHoras");

            migrationBuilder.DropTable(
                name: "Desenvolvedores");

            migrationBuilder.DropTable(
                name: "DevsEmProjetosTable");

            migrationBuilder.DropTable(
                name: "HorasAcomuladasDev");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
