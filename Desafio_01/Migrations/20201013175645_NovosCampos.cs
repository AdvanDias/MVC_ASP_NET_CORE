using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_01.Migrations
{
    public partial class NovosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nometipo",
                table: "tipoExames",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nomeexame",
                table: "Exames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nometipo",
                table: "tipoExames");

            migrationBuilder.DropColumn(
                name: "Nomeexame",
                table: "Exames");
        }
    }
}
