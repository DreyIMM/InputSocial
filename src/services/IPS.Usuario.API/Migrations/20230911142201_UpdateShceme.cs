using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPS.Usuario.API.Migrations
{
    public partial class UpdateShceme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuarios",
                newSchema: "public");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Usuarios",
                schema: "public",
                newName: "Usuarios");
        }
    }
}
