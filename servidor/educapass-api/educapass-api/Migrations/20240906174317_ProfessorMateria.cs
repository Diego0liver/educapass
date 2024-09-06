using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace educapass_api.Migrations
{
    /// <inheritdoc />
    public partial class ProfessorMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessorMateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Materia_id = table.Column<int>(type: "integer", nullable: false),
                    Professor_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorMateria_Materia_Materia_id",
                        column: x => x.Materia_id,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorMateria_Professor_Professor_id",
                        column: x => x.Professor_id,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorMateria_Materia_id",
                table: "ProfessorMateria",
                column: "Materia_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorMateria_Professor_id",
                table: "ProfessorMateria",
                column: "Professor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorMateria");
        }
    }
}
