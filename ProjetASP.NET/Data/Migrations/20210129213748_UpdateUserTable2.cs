using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class UpdateUserTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departements_IdDept",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdDept",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdDept",
                table: "AspNetUsers",
                column: "IdDept");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departements_IdDept",
                table: "AspNetUsers",
                column: "IdDept",
                principalTable: "Departements",
                principalColumn: "IdDept",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
