using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class AddTablesTravails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travails",
                columns: table => new
                {
                    idTravail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    DateRemis = table.Column<string>(nullable: false),
                    Note = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travails", x => x.idTravail);
                });

            migrationBuilder.CreateTable(
                name: "Travaux",
                columns: table => new
                {
                    idTravaux = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    DateDelai = table.Column<string>(nullable: false),
                    File = table.Column<string>(nullable: true),
                    IdElement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travaux", x => x.idTravaux);
                    table.ForeignKey(
                        name: "FK_Travaux_Elements_IdElement",
                        column: x => x.IdElement,
                        principalTable: "Elements",
                        principalColumn: "IdElement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travaux_IdElement",
                table: "Travaux",
                column: "IdElement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travails");

            migrationBuilder.DropTable(
                name: "Travaux");
        }
    }
}
