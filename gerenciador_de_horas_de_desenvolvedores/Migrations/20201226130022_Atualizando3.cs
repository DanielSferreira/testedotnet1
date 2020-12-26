using Microsoft.EntityFrameworkCore.Migrations;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    public partial class Atualizando3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HorasAcomuladas",
                table: "HorasAcomuladasDev",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HorasAcomuladas",
                table: "HorasAcomuladasDev",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
