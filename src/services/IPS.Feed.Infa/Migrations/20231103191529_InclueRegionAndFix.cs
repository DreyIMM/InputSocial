using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPS.Feed.Infa.Migrations
{
    public partial class InclueRegionAndFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    DataPostagems = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Modificado = table.Column<bool>(type: "boolean", nullable: false),
                    Mensagem = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Regiao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postagens", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPostagem = table.Column<Guid>(type: "uuid", nullable: false),
                    Mensagem = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Postagens_IdPostagem",
                        column: x => x.IdPostagem,
                        principalTable: "Postagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curtidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPostagem = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCurtida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curtidas_Postagens_IdPostagem",
                        column: x => x.IdPostagem,
                        principalTable: "Postagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPostagem",
                table: "Comentarios",
                column: "IdPostagem");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_IdPostagem",
                table: "Curtidas",
                column: "IdPostagem");

            migrationBuilder.CreateIndex(
                name: "IX_Seguidores_IdUsuario_IdSeguidores",
                table: "Seguidores",
                columns: new[] { "IdUsuario", "IdSeguidores" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Curtidas");

            migrationBuilder.DropTable(
                name: "Seguidores");

            migrationBuilder.DropTable(
                name: "Postagens");
        }
    }
}
