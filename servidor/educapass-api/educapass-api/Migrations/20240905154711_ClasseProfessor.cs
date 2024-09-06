using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace educapass_api.Migrations
{
    /// <inheritdoc />
    public partial class ClasseProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasseProfessor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Clase_id = table.Column<int>(type: "integer", nullable: false),
                    Professor_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseProfessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClasseProfessor_Clase_Clase_id",
                        column: x => x.Clase_id,
                        principalTable: "Clase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClasseProfessor_Professor_Professor_id",
                        column: x => x.Professor_id,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClasseProfessor_Clase_id",
                table: "ClasseProfessor",
                column: "Clase_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClasseProfessor_Professor_id",
                table: "ClasseProfessor",
                column: "Professor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasseProfessor");
        }
    }
}
