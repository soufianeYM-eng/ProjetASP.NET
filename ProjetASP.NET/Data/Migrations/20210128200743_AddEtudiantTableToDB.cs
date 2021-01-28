using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class AddEtudiantTableToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    CodeApogee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    IdFil = table.Column<int>(nullable: false),
                    Année = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.CodeApogee);
                    table.ForeignKey(
                        name: "FK_Etudiants_Filieres_IdFil",
                        column: x => x.IdFil,
                        principalTable: "Filieres",
                        principalColumn: "IdFil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Etudiants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_IdFil",
                table: "Etudiants",
                column: "IdFil");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_UserId",
                table: "Etudiants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etudiants");
        }
    }
}
