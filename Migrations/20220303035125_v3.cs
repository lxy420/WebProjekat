using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert");

            migrationBuilder.DropIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert");

            migrationBuilder.CreateTable(
                name: "KoncertSala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KoncertId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoncertSala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KoncertSala_Koncert_KoncertId",
                        column: x => x.KoncertId,
                        principalTable: "Koncert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KoncertSala_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KoncertSala_KoncertId",
                table: "KoncertSala",
                column: "KoncertId");

            migrationBuilder.CreateIndex(
                name: "IX_KoncertSala_SalaId",
                table: "KoncertSala",
                column: "SalaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KoncertSala");

            migrationBuilder.CreateIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
