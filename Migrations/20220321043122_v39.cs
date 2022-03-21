using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Koncert_KoncertId",
                table: "Rezervacija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_KoncertId",
                table: "Rezervacija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KoncertId",
                table: "Rezervacija",
                column: "KoncertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Koncert_KoncertId",
                table: "Rezervacija",
                column: "KoncertId",
                principalTable: "Koncert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
