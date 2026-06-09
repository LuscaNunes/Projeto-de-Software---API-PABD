using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trabalho_Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarEmailAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Alunos");
        }
    }
}
