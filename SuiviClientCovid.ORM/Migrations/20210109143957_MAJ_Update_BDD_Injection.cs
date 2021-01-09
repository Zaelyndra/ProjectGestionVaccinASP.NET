using Microsoft.EntityFrameworkCore.Migrations;

namespace SuiviClientCovid.ORM.Migrations
{
    public partial class MAJ_Update_BDD_Injection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injections_Personnes_PersonneId",
                table: "Injections");

            migrationBuilder.AlterColumn<int>(
                name: "PersonneId",
                table: "Injections",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Injections_Personnes_PersonneId",
                table: "Injections",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injections_Personnes_PersonneId",
                table: "Injections");

            migrationBuilder.AlterColumn<int>(
                name: "PersonneId",
                table: "Injections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Injections_Personnes_PersonneId",
                table: "Injections",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
