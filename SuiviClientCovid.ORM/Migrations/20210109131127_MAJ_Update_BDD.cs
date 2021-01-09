using Microsoft.EntityFrameworkCore.Migrations;

namespace SuiviClientCovid.ORM.Migrations
{
    public partial class MAJ_Update_BDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypesVaccins_Injections_InjectionId",
                table: "TypesVaccins");

            migrationBuilder.DropIndex(
                name: "IX_TypesVaccins_InjectionId",
                table: "TypesVaccins");

            migrationBuilder.DropColumn(
                name: "InjectionId",
                table: "TypesVaccins");

            migrationBuilder.AddColumn<int>(
                name: "TypesVaccinId",
                table: "Injections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Injections_TypesVaccinId",
                table: "Injections",
                column: "TypesVaccinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Injections_TypesVaccins_TypesVaccinId",
                table: "Injections",
                column: "TypesVaccinId",
                principalTable: "TypesVaccins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injections_TypesVaccins_TypesVaccinId",
                table: "Injections");

            migrationBuilder.DropIndex(
                name: "IX_Injections_TypesVaccinId",
                table: "Injections");

            migrationBuilder.DropColumn(
                name: "TypesVaccinId",
                table: "Injections");

            migrationBuilder.AddColumn<int>(
                name: "InjectionId",
                table: "TypesVaccins",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TypesVaccins_InjectionId",
                table: "TypesVaccins",
                column: "InjectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypesVaccins_Injections_InjectionId",
                table: "TypesVaccins",
                column: "InjectionId",
                principalTable: "Injections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
