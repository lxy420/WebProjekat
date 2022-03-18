using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert");

            migrationBuilder.CreateIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert",
                column: "SalaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert");

            migrationBuilder.CreateIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert",
                column: "SalaId");
        }
    }
}
