using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPS.Feed.API.Migrations
{
    public partial class RelacaoSeguindoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguidores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSeguidores = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_IdUsuario_IdSeguidores",
                table: "Seguidores",
                columns: new[] { "IdUsuario", "IdSeguidores" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguidores");
        }
    }
}
