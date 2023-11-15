using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPS.Feed.Infa.Migrations
{
    public partial class InclueEntidadeNLP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntidadesNlp",
                table: "Postagens",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntidadesNlp",
                table: "Postagens");
        }
    }
}
