using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class UpdateTableFiliere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFil",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modules_IdFil",
                table: "Modules",
                column: "IdFil");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Filieres_IdFil",
                table: "Modules",
                column: "IdFil",
                principalTable: "Filieres",
                principalColumn: "IdFil",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Filieres_IdFil",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_IdFil",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "IdFil",
                table: "Modules");
        }
    }
}
