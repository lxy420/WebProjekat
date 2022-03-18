using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Redovi",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "KodRezervacije",
                table: "Rezervacija");

            migrationBuilder.RenameColumn(
                name: "RedniBrojSedista",
                table: "Rezervacija",
                newName: "Sediste");

            migrationBuilder.RenameColumn(
                name: "OpisRezervacije",
                table: "Rezervacija",
                newName: "Telefon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefon",
                table: "Rezervacija",
                newName: "OpisRezervacije");

            migrationBuilder.RenameColumn(
                name: "Sediste",
                table: "Rezervacija",
                newName: "RedniBrojSedista");

            migrationBuilder.AddColumn<int>(
                name: "Redovi",
                table: "Sala",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "KodRezervacije",
                table: "Rezervacija",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
