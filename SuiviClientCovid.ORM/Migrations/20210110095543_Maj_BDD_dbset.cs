using Microsoft.EntityFrameworkCore.Migrations;

namespace SuiviClientCovid.ORM.Migrations
{
    public partial class Maj_BDD_dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnes_Sexe_SexeId",
                table: "Personnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sexe",
                table: "Sexe");

            migrationBuilder.RenameTable(
                name: "Sexe",
                newName: "Sexes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sexes",
                table: "Sexes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnes_Sexes_SexeId",
                table: "Personnes",
                column: "SexeId",
                principalTable: "Sexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personnes_Sexes_SexeId",
                table: "Personnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sexes",
                table: "Sexes");

            migrationBuilder.RenameTable(
                name: "Sexes",
                newName: "Sexe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sexe",
                table: "Sexe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personnes_Sexe_SexeId",
                table: "Personnes",
                column: "SexeId",
                principalTable: "Sexe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
