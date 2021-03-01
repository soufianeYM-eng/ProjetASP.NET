using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class AddSeanceTableToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    idSeance = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    LienSeance = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IdElement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.idSeance);
                    table.ForeignKey(
                        name: "FK_Seances_Elements_IdElement",
                        column: x => x.IdElement,
                        principalTable: "Elements",
                        principalColumn: "IdElement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seances_IdElement",
                table: "Seances",
                column: "IdElement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seances");
        }
    }
}
