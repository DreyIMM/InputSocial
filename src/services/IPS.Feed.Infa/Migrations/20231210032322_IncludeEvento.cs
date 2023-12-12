using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPS.Feed.Infa.Migrations
{
    public partial class IncludeEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EntidadesNlp",
                table: "Postagens",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uuid", nullable: false),
                    TituloEvento = table.Column<string>(type: "varchar(150)", nullable: false),
                    DescricaoEvento = table.Column<string>(type: "varchar(300)", nullable: false),
                    Limite = table.Column<bool>(type: "boolean", nullable: false),
                    QuantidadePessoas = table.Column<int>(type: "integer", nullable: true),
                    StatusEvento = table.Column<string>(type: "text", nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "text", nullable: true),
                    Endereco_Regiao = table.Column<string>(type: "text", nullable: true),
                    Endereco_Numero = table.Column<string>(type: "text", nullable: true),
                    Endereco_cep = table.Column<string>(type: "text", nullable: true),
                    Endereco_Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Endereco_Longitude = table.Column<double>(type: "double precision", nullable: true),
                    Endereco_EventoGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Endereco_Id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.AlterColumn<string>(
                name: "EntidadesNlp",
                table: "Postagens",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
