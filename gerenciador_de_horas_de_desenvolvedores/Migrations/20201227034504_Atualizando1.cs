using Microsoft.EntityFrameworkCore.Migrations;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    public partial class Atualizando1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevsEmProjetosTable_Projetos_ProjetoTableId",
                table: "DevsEmProjetosTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevsEmProjetosTable",
                table: "DevsEmProjetosTable");

            migrationBuilder.RenameTable(
                name: "DevsEmProjetosTable",
                newName: "DevsEmProjetos");

            migrationBuilder.RenameIndex(
                name: "IX_DevsEmProjetosTable_ProjetoTableId",
                table: "DevsEmProjetos",
                newName: "IX_DevsEmProjetos_ProjetoTableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevsEmProjetos",
                table: "DevsEmProjetos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DevsEmProjetos_Projetos_ProjetoTableId",
                table: "DevsEmProjetos",
                column: "ProjetoTableId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevsEmProjetos_Projetos_ProjetoTableId",
                table: "DevsEmProjetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevsEmProjetos",
                table: "DevsEmProjetos");

            migrationBuilder.RenameTable(
                name: "DevsEmProjetos",
                newName: "DevsEmProjetosTable");

            migrationBuilder.RenameIndex(
                name: "IX_DevsEmProjetos_ProjetoTableId",
                table: "DevsEmProjetosTable",
                newName: "IX_DevsEmProjetosTable_ProjetoTableId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevsEmProjetosTable",
                table: "DevsEmProjetosTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DevsEmProjetosTable_Projetos_ProjetoTableId",
                table: "DevsEmProjetosTable",
                column: "ProjetoTableId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
