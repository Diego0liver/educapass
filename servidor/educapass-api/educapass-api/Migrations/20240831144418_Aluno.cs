using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace educapass_api.Migrations
{
    /// <inheritdoc />
    public partial class Aluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Inscricao = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: true),
                    Responsavel = table.Column<string>(type: "text", nullable: true),
                    ContatoResponsavel = table.Column<string>(type: "text", nullable: true),
                    NumeroChamada = table.Column<int>(type: "integer", nullable: true),
                    TotalFalta = table.Column<int>(type: "integer", nullable: true),
                    Telefone = table.Column<int>(type: "text", nullable: true),
                    Escola_id = table.Column<int>(type: "integer", nullable: false),
                    Clase_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Clase_Clase_id",
                        column: x => x.Clase_id,
                        principalTable: "Clase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aluno_Escola_Escola_id",
                        column: x => x.Escola_id,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Clase_id",
                table: "Aluno",
                column: "Clase_id");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Escola_id",
                table: "Aluno",
                column: "Escola_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
