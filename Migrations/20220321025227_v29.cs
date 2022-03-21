using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KoncertIzvodjac");

            migrationBuilder.AddColumn<int>(
                name: "IzvodjacId",
                table: "Koncert",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Koncert_IzvodjacId",
                table: "Koncert",
                column: "IzvodjacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Koncert_Izvodjac_IzvodjacId",
                table: "Koncert",
                column: "IzvodjacId",
                principalTable: "Izvodjac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koncert_Izvodjac_IzvodjacId",
                table: "Koncert");

            migrationBuilder.DropIndex(
                name: "IX_Koncert_IzvodjacId",
                table: "Koncert");

            migrationBuilder.DropColumn(
                name: "IzvodjacId",
                table: "Koncert");

            migrationBuilder.CreateTable(
                name: "KoncertIzvodjac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzvodjacId = table.Column<int>(type: "int", nullable: false),
                    KoncertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KoncertIzvodjac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KoncertIzvodjac_Izvodjac_IzvodjacId",
                        column: x => x.IzvodjacId,
                        principalTable: "Izvodjac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KoncertIzvodjac_Koncert_KoncertId",
                        column: x => x.KoncertId,
                        principalTable: "Koncert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KoncertIzvodjac_IzvodjacId",
                table: "KoncertIzvodjac",
                column: "IzvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_KoncertIzvodjac_KoncertId",
                table: "KoncertIzvodjac",
                column: "KoncertId");
        }
    }
}
