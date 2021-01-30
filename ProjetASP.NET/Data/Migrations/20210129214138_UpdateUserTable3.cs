using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class UpdateUserTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Filieres_IdFil",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdFil",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdFil",
                table: "AspNetUsers",
                column: "IdFil");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Filieres_IdFil",
                table: "AspNetUsers",
                column: "IdFil",
                principalTable: "Filieres",
                principalColumn: "IdFil",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
