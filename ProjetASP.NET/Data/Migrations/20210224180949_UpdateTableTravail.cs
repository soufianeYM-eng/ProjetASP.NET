using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class UpdateTableTravail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idTravaux",
                table: "Travails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Travails_idTravaux",
                table: "Travails",
                column: "idTravaux");

            migrationBuilder.AddForeignKey(
                name: "FK_Travails_Travaux_idTravaux",
                table: "Travails",
                column: "idTravaux",
                principalTable: "Travaux",
                principalColumn: "idTravaux",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travails_Travaux_idTravaux",
                table: "Travails");

            migrationBuilder.DropIndex(
                name: "IX_Travails_idTravaux",
                table: "Travails");

            migrationBuilder.DropColumn(
                name: "idTravaux",
                table: "Travails");
        }
    }
}
