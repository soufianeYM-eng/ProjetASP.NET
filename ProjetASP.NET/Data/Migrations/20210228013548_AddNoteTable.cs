using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetASP.NET.Data.Migrations
{
    public partial class AddNoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteElements",
                columns: table => new
                {
                    idNote = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdElement = table.Column<int>(nullable: false),
                    idEtudiant = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteElements", x => x.idNote);
                    table.ForeignKey(
                        name: "FK_NoteElements_Elements_IdElement",
                        column: x => x.IdElement,
                        principalTable: "Elements",
                        principalColumn: "IdElement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteElements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteElements_IdElement",
                table: "NoteElements",
                column: "IdElement");

            migrationBuilder.CreateIndex(
                name: "IX_NoteElements_UserId",
                table: "NoteElements",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteElements");
        }
    }
}
