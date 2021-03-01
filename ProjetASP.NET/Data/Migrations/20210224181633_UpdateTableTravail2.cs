using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class UpdateTableTravail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Travails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travails_UserId",
                table: "Travails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travails_AspNetUsers_UserId",
                table: "Travails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travails_AspNetUsers_UserId",
                table: "Travails");

            migrationBuilder.DropIndex(
                name: "IX_Travails_UserId",
                table: "Travails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Travails");
        }
    }
}
