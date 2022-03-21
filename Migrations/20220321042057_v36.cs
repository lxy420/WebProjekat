using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Koncert_KoncertId",
                table: "Rezervacija");

            migrationBuilder.AlterColumn<int>(
                name: "KoncertId",
                table: "Rezervacija",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Koncert_KoncertId",
                table: "Rezervacija",
                column: "KoncertId",
                principalTable: "Koncert",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Koncert_KoncertId",
                table: "Rezervacija");

            migrationBuilder.AlterColumn<int>(
                name: "KoncertId",
                table: "Rezervacija",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
