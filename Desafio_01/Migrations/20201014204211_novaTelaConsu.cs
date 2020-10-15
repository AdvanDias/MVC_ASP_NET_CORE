using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio_01.Migrations
{
    public partial class novaTelaConsu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcaConsus");

            migrationBuilder.CreateTable(
                name: "ConsultaMarcas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filtranome = table.Column<string>(nullable: true),
                    Filtracpf = table.Column<string>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    NumeroProtocolo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaMarcas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultaMarcas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaMarcas_PacienteId",
                table: "ConsultaMarcas",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaMarcas");

            migrationBuilder.CreateTable(
                name: "MarcaConsus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExameId = table.Column<int>(type: "int", nullable: true),
                    Filtracpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filtranome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroProtocolo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    SelecionaTipoExame = table.Column<int>(type: "int", nullable: false),
                    TipoExameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaConsus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarcaConsus_Exames_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarcaConsus_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarcaConsus_tipoExames_TipoExameId",
                        column: x => x.TipoExameId,
                        principalTable: "tipoExames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarcaConsus_ExameId",
                table: "MarcaConsus",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaConsus_PacienteId",
                table: "MarcaConsus",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcaConsus_TipoExameId",
                table: "MarcaConsus",
                column: "TipoExameId");
        }
    }
}
