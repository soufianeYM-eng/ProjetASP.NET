using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class AddElementsTableToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    IdElement = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: false),
                    pourcentage = table.Column<float>(nullable: false),
                    IdModule = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.IdElement);
                    table.ForeignKey(
                        name: "FK_Elements_Modules_IdModule",
                        column: x => x.IdModule,
                        principalTable: "Modules",
                        principalColumn: "IdModule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elements_IdModule",
                table: "Elements",
                column: "IdModule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");
        }
    }
}
