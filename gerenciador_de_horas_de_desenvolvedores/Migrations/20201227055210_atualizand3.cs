using Microsoft.EntityFrameworkCore.Migrations;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    public partial class atualizand3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevsEmProjetos_Projetos_ProjetoTableId",
                table: "DevsEmProjetos");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "DevsEmProjetos");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoTableId",
                table: "DevsEmProjetos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DevsEmProjetos_Projetos_ProjetoTableId",
                table: "DevsEmProjetos",
                column: "ProjetoTableId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevsEmProjetos_Projetos_ProjetoTableId",
                table: "DevsEmProjetos");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoTableId",
                table: "DevsEmProjetos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "DevsEmProjetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DevsEmProjetos_Projetos_ProjetoTableId",
                table: "DevsEmProjetos",
                column: "ProjetoTableId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
