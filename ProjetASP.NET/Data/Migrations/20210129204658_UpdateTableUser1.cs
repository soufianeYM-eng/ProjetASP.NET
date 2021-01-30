using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class UpdateTableUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDept",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFil",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdDept",
                table: "AspNetUsers",
                column: "IdDept");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdFil",
                table: "AspNetUsers",
                column: "IdFil");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departements_IdDept",
                table: "AspNetUsers",
                column: "IdDept",
                principalTable: "Departements",
                principalColumn: "IdDept",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Filieres_IdFil",
                table: "AspNetUsers",
                column: "IdFil",
                principalTable: "Filieres",
                principalColumn: "IdFil",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departements_IdDept",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Filieres_IdFil",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdDept",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdFil",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDept",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdFil",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Departement",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Filiere",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
