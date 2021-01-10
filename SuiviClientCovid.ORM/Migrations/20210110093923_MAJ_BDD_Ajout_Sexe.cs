using Microsoft.EntityFrameworkCore.Migrations;

namespace SuiviClientCovid.ORM.Migrations
{
    public partial class MAJ_BDD_Ajout_Sexe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injections_Personnes_PersonneId",
                table: "Injections");

            migrationBuilder.AddColumn<int>(
                name: "SexeId",
                table: "Personnes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PersonneId",
                table: "Injections",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Sexe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_SexeId",
                table: "Personnes",
                column: "SexeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Injections_Personnes_PersonneId",
                table: "Injections",
                column: "PersonneId",
                principalTable: "Personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personnes_Sexe_SexeId",
                table: "Personnes",
                column: "SexeId",
                principalTable: "Sexe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Injections_Personnes_PersonneId",
                table: "Injections");

            migrationBuilder.DropForeignKey(
                name: "FK_Personnes_Sexe_SexeId",
                table: "Personnes");

            migrationBuilder.DropTable(
                name: "Sexe");

            migrationBuilder.DropIndex(
                name: "IX_Personnes_SexeId",
                table: "Personnes");

            migrationBuilder.DropColumn(
                name: "SexeId",
                table: "Personnes");

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
    }
}
