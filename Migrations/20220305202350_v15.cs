using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_projekat.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert");

            migrationBuilder.DropIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert");

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Koncert",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Koncert",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Koncert_SalaId",
                table: "Koncert",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Koncert_Sala_SalaId",
                table: "Koncert",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "Id");
        }
    }
}
