using Microsoft.EntityFrameworkCore.Migrations;

namespace SuiviClientCovid.ORM.Migrations
{
    public partial class Update_BDD_Personne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexe",
                table: "Personnes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sexe",
                table: "Personnes",
                type: "INTEGER",
                nullable: true);
        }
    }
}
